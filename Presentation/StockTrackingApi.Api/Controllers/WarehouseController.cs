using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.Warehouses.Queries.GetAllListWarehouse;

namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IMediator mediator;
        public WarehouseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWarehouse()
        {
            var response = await mediator.Send(new GetAllWarehouseQueryRequest());
            return Ok(response);
        }
    }
}
