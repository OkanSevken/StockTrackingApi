using MediatR;
using StockTrackingApi.Application.Features.CarBrandModels.Queries.GetAllListCarBrandModels;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartBrandModels.Queries.GetAllListPartBrandModels
{
    public class GetAllListPartBrandModelsQueryHandler : IRequestHandler<GetAllListPartBrandModelsQueryRequest, IList<GetAllListPartBrandModelsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllListPartBrandModelsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GetAllListPartBrandModelsQueryResponse>> Handle(GetAllListPartBrandModelsQueryRequest request, CancellationToken cancellationToken)
        {
            var partBrandModels = await unitOfWork.GetReadRepository<PartBrandModel>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);

            List<GetAllListPartBrandModelsQueryResponse> map = new List<GetAllListPartBrandModelsQueryResponse>();

            foreach (var partBrandModel in partBrandModels)
            {
                map.Add(new GetAllListPartBrandModelsQueryResponse
                {
                    Id = partBrandModel.Id,
                    Brand = partBrandModel.Brand,
                    Model = partBrandModel.Model,
                    Category = partBrandModel.Category,
                });
            }
            return map;
        }
    }
}
