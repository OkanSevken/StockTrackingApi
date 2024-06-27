using MediatR;
using StockTrackingApi.Application.Features.Warehouses.Queries.GetAllListWarehouse;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Categories.Queries.GetAllListCategories
{
    public class GetAllListCategoriesQueryHandler : IRequestHandler<GetAllListCategoriesQueryRequest, IList<GetAllListCategoriesQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllListCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllListCategoriesQueryResponse>> Handle(GetAllListCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);

            List<GetAllListCategoriesQueryResponse> map = new List<GetAllListCategoriesQueryResponse>();

            foreach (var category in categories)
            {
                map.Add(new GetAllListCategoriesQueryResponse
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName
                });
            }
            return map;
        }
    }
}
