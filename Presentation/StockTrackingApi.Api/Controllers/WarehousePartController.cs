using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.WarehouseParts.Queries.GetAllListWarehouseParts;

namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehousePartController : ControllerBase
    {
        private readonly IMediator mediator;

        public WarehousePartController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWarehouseParts()
        {
            var response = await mediator.Send(new GetAllWarehousePartsQueryRequest());
            return Ok(response);
        }
    }
}
