using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.PartModels.Queries.GetListPartModelsFromBrand;
using StockTrackingApi.Application.Features.PartMovements.Queries.GetListPartMovementsFromPart;

namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartModelController : ControllerBase
    {
        private readonly IMediator mediator;
        public PartModelController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> GetListPartModelsFromBrand(int id)
        {
            var response = await mediator.Send(new GetListPartModelsFromBrandQueryRequest { Id = id });
            return Ok(response);
        }
    }
}
