using MediatR;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarBrandModels.Queries.GetAllListCarBrandModels
{
    public class GetAllListCarBrandModelsQueryHandler : IRequestHandler<GetAllListCarBrandModelsQueryRequest, IList<GetAllListCarBrandModelsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllListCarBrandModelsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllListCarBrandModelsQueryResponse>> Handle(GetAllListCarBrandModelsQueryRequest request, CancellationToken cancellationToken)
        {
            var carBrandModels = await unitOfWork.GetReadRepository<CarBrandModel>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
           
            List<GetAllListCarBrandModelsQueryResponse> map = new List<GetAllListCarBrandModelsQueryResponse>();

            foreach (var carBrandModel in carBrandModels)
            {
                map.Add(new GetAllListCarBrandModelsQueryResponse
                {
                    Id = carBrandModel.Id,
                    Brand=carBrandModel.Brand,
                    Model=carBrandModel.Model, 
                    Year=carBrandModel.Year,
                });
            }
            return map;
        }
    }
}
