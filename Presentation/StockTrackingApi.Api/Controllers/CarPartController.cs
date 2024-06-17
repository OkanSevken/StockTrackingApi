using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.CarParts.Command.CreateCarParts;
using StockTrackingApi.Application.Features.CarParts.Command.DeleteCarParts;
using StockTrackingApi.Application.Features.CarParts.Command.UpdateCarParts;
using StockTrackingApi.Application.Features.CarParts.Queries.GetAllListCarParts;


namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarPartController : ControllerBase
    {
        private readonly IMediator mediator;
        public CarPartController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCarParts()
        {
            var response = await mediator.Send(new GetAllCarPartsQueryRequest());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarParts(CreateCarPartsCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateCarParts(UpdateCarPartsCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCarParts(DeleteCarPartsCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
