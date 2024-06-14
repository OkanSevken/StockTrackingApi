using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.PartMovements.Command.CreatePartMovement;

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
        [HttpPost]
        public async Task<IActionResult> CreatePartMovements(CreatePartMovementCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
