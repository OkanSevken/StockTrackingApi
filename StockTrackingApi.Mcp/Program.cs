using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockTrackingApi.Application; 
using StockTrackingApi.Persistence;
using StockTrackingApi.Persistence.Context; 
using StockTrackingApi.Domain.Entities;     

namespace StockTrackingApi.McpServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 1. HOST VE DEPENDENCY INJECTION KURULUMU
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    // API projesindeki appsettings.json dosyasını okuyoruz
                    config.SetBasePath(AppContext.BaseDirectory);
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddApplication();

                    services.AddPersistence(context.Configuration);
                })
                .Build();

            SeedDatabase(host);

            using (var scope = host.Services.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                while (true)
                {
                    try
                    {
                        var inputLine = await Console.In.ReadLineAsync();
                        if (string.IsNullOrWhiteSpace(inputLine)) continue;

                        var request = JObject.Parse(inputLine);
                        var method = request["method"]?.ToString();
                        var id = request["id"]; 

    
                        if (method == "initialize")
                        {
                            var response = new
                            {
                                jsonrpc = "2.0",
                                id = id,
                                result = new
                                {
                                    protocolVersion = "2024-11-05",
                                    capabilities = new { tools = new { } },
                                    serverInfo = new { name = "StockTrackingMcp", version = "1.0" }
                                }
                            };
                            SendJson(response);
                        }
                        else if (method == "tools/list")
                        {
                            var response = new
                            {
                                jsonrpc = "2.0",
                                id = id,
                                result = new
                                {
                                    tools = new[]
                                    {
                                        new
                                        {
                                            name = "get_all_stocks",
                                            description = "Veritabanindaki tum stoklari listeler.",
                                            inputSchema = new { type = "object", properties = new { } }
                                        }
                                    }
                                }
                            };
                            SendJson(response);
                        }
                        else if (method == "tools/call")
                        {
                            var paramsObj = request["params"];
                            var toolName = paramsObj?["name"]?.ToString();

                            object resultData = null;

                            // --- CQRS BAĞLANTISI ---
                            switch (toolName)
                            {
                                case "get_all_stocks":
                                    using (var serviceScope = host.Services.CreateScope())
                                    {
                                        var db = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                                        resultData = db.Categories.ToList();
                                    }
                                    break;

                                default:
                                    throw new Exception($"Tool bulunamadı: {toolName}");
                            }

                            // Sonucu yapay zekaya gönder
                            var response = new
                            {
                                jsonrpc = "2.0",
                                id = id,
                                result = new
                                {
                                    content = new[]
                                    {
                                        new { type = "text", text = JsonConvert.SerializeObject(resultData) }
                                    }
                                }
                            };
                            SendJson(response);
                        }
                    }
                    catch (Exception ex)
                    {
                      
                    }
                }
            }
        }

        static void SendJson(object data)
        {
            Console.WriteLine(JsonConvert.SerializeObject(data));
        }

        static void SeedDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { CategoryName = "xxx", CreaterUserId= 1, IsActive = true },
                    new Category { CategoryName = "yyy", CreaterUserId = 1, IsActive = true },
                    new Category { CategoryName = "zzz", CreaterUserId = 1, IsActive = true }
                );
                context.SaveChanges();
                Console.Error.WriteLine("--> InMemory veritabanına veriler eklendi.");
            }
        }
    }


    }