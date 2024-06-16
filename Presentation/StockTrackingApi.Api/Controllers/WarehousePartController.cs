using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.WarehouseParts.Command.CreateWarehousePart;
using StockTrackingApi.Application.Features.WarehouseParts.Command.DeleteWarehousePart;
using StockTrackingApi.Application.Features.WarehouseParts.Command.UpdateWarehousePart;
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

        [HttpPost]
        public async Task<IActionResult> CreateWarehouseParts(CreateWarehousePartCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateWarehouseParts(UpdateWarehousePartCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteWarehouseParts(DeleteWarehousePartCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
