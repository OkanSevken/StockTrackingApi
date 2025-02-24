﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.CarModels.Command.CreateCarModel;
using StockTrackingApi.Application.Features.CarModels.Queries.GetListCarModelsFromBrand;

namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarModelController : ControllerBase
    {
        private readonly IMediator mediator;
        public CarModelController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> GetListCarModelsFromBrand(int id)
        {
            var response = await mediator.Send(new GetListCarModelsFromBrandQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarModel(CreateCarModelCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
