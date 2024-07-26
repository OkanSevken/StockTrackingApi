using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTrackingApi.Application.Features.Categories.Command.CreateCategory;
using StockTrackingApi.Application.Features.Categories.Queries.GetAllListCategories;


namespace StockTrackingApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var response = await mediator.Send(new GetAllListCategoriesQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategories(CreateCategoryCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
