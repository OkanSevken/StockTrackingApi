using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.CarBrandModels.Command.CreateCarBrandModel;
using StockTrackingApi.Application.Features.CarBrandModels.Command.DeleteCarBrandModel;
using StockTrackingApi.Application.Features.CarBrandModels.Command.UpdateCarBrandModel;
using StockTrackingApi.Application.Features.CarBrandModels.Queries.GetAllListCarBrandModels;

namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarBrandModelController : ControllerBase
    {
        private readonly IMediator mediator;
        public CarBrandModelController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarBrandModels()
        {
            var response = await mediator.Send(new GetAllListCarBrandModelsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarBrandModels(CreateCarBrandModelCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateCarBrandModels(UpdateCarBrandModelCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCarBrandModels(DeleteCarBrandModelCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
