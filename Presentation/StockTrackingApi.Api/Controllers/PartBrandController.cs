using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.PartBrands.Queries.GetAllListPartBrands;
using StockTrackingApi.Application.Features.PartBrands.Queries.GetListPartBrandsFromCarModels;
using StockTrackingApi.Application.Features.PartModels.Queries.GetListPartModelsFromBrand;

namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartBrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public PartBrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPartBrands()
        {
            var response = await mediator.Send(new GetAllListPartBrandsQueryRequest());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetListPartBrandsFromCarModels(int id)
        {
            var response = await mediator.Send(new GetListPartBrandsFromCarModelsQueryRequest { Id = id });
            return Ok(response);
        }
    }
}
