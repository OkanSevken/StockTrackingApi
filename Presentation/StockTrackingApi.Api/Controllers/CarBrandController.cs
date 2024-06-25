using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.CarBrands.Queries.GetAllListCarBrands;

namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarBrandController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarBrandController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarBrands()
        {
            var response = await mediator.Send(new GetAllListCarBrandsQueryRequest());

            return Ok(response);
        }
    }
}
