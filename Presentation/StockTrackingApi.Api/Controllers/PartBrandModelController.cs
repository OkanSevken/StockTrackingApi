using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.PartBrandModels.Command.CreatePartBrandModel;
using StockTrackingApi.Application.Features.PartBrandModels.Command.DeletePartBrandModel;
using StockTrackingApi.Application.Features.PartBrandModels.Command.UpdatePartBrandModel;
using StockTrackingApi.Application.Features.PartBrandModels.Queries.GetAllListPartBrandModels;

namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartBrandModelController : ControllerBase
    {
        private readonly IMediator mediator;
        public PartBrandModelController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPartBrandModels()
        {
            var response = await mediator.Send(new GetAllListPartBrandModelsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartBrandModels(CreatePartBrandModelCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]

        public async Task<IActionResult> UpdatePartBrandModels(UpdatePartBrandModelCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePartBrandModels(DeletePartBrandModelCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
