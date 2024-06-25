using MediatR;
using StockTrackingApi.Application.Features.PartModels.Queries.GetListPartModelsFromBrand;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarModels.Queries.GetListCarModelsFromBrand
{
    public class GetListCarModelsFromBrandQueryHandler : IRequestHandler<GetListCarModelsFromBrandQueryRequest, IList<GetListCarModelsFromBrandQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetListCarModelsFromBrandQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetListCarModelsFromBrandQueryResponse>> Handle(GetListCarModelsFromBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var carModels = await unitOfWork.GetReadRepository<CarModel>().GetAllAsync(x => x.CarBrandId == request.Id && x.IsActive && !x.IsDeleted);
            var carBrands = await unitOfWork.GetReadRepository<CarBrand>().GetAllAsync(x => x.IsActive && !x.IsDeleted);

            List<GetListCarModelsFromBrandQueryResponse> map = new List<GetListCarModelsFromBrandQueryResponse>();
            foreach (var carModel in carModels)
            {
                var carBrand = carBrands.FirstOrDefault(x => x.Id == carModel.CarBrandId);
                map.Add(new GetListCarModelsFromBrandQueryResponse
                {
                    Id = carModel.Id,
                    ModelName = carModel.ModelName,
                    Year = carModel.Year,
                    CarBrandName=carBrand.BrandName
                });
            }
            return map;
        }
    }
}
