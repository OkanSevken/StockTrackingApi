using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.Parts.Command.CreatePart;
using StockTrackingApi.Application.Features.Parts.Command.DeletePart;
using StockTrackingApi.Application.Features.Parts.Command.UpdatePart;
using StockTrackingApi.Application.Features.Parts.Queries.GetAllListParts;
using StockTrackingApi.Application.Features.Parts.Queries.GetListPartsFromBrand;

namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IMediator mediator;
        public PartController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParts()
        {
            var response = await mediator.Send(new GetAllPartsQueryRequest());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> GetListPartsFromBrand(string name)
        {
            var response = await mediator.Send(new GetListPartsFromBrandQueryRequest { BrandName = name });
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateParts(CreatePartCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]

        public async Task<IActionResult> UpdateParts(UpdatePartCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteParts(DeletePartCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
