using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.Warehouses.Command.CreateWarehouse;
using StockTrackingApi.Application.Features.Warehouses.Command.DeleteWarehouse;
using StockTrackingApi.Application.Features.Warehouses.Command.UpdateWarehouse;
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

        [HttpPost]
        public async Task<IActionResult> CreateWarehouses(CreateWarehouseCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateWarehouses(UpdateWarehouseCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWarehouses(DeleteWarehouseCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
