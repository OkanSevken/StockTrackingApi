using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.PartMovements.Command.CreatePartMovement;
using StockTrackingApi.Application.Features.PartMovements.Queries.GetAllListPartMovements;
using StockTrackingApi.Application.Features.PartMovements.Queries.GetListPartMovementsFromPart;


namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PartMovementController : ControllerBase
    {
        private readonly IMediator mediator;
        public PartMovementController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPartMovements()
        {
            var response = await mediator.Send(new GetAllListPartMovementsQueryRequest());
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> GetListPartMovementsFromPart(int id)
        {
            var response = await mediator.Send(new GetListPartMovementsFromPartQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePartMovements(CreatePartMovementCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
