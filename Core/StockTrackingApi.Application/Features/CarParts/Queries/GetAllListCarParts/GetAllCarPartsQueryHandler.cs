using MediatR;
using StockTrackingApi.Application.Features.WarehouseParts.Queries.GetAllListWarehouseParts;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarParts.Queries.GetAllListCarParts
{
    public class GetAllCarPartsQueryHandler : IRequestHandler<GetAllCarPartsQueryRequest, IList<GetAllCarPartsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllCarPartsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GetAllCarPartsQueryResponse>> Handle(GetAllCarPartsQueryRequest request, CancellationToken cancellationToken)
        {
            var carParts = await unitOfWork.GetReadRepository<CarPart>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var carModels = await unitOfWork.GetReadRepository<CarModel>().GetAllAsync(x => x.IsActive && x.IsDeleted == false);
            var partModels = await unitOfWork.GetReadRepository<PartModel>().GetAllAsync(x => x.IsActive && x.IsDeleted == false);
            var carBrands = await unitOfWork.GetReadRepository<CarBrand>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var partBrands = await unitOfWork.GetReadRepository<PartBrand>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);

            List<GetAllCarPartsQueryResponse> map = new List<GetAllCarPartsQueryResponse>();

            foreach (var carPart in carParts)
            {
                var carModel = carModels.FirstOrDefault(w => w.Id == carPart.CarModelId);
                var partModel = partModels.FirstOrDefault(p => p.Id == carPart.PartModelId);
                var carBrand = carBrands.FirstOrDefault(c => c.Id == carModel.CarBrandId);
                var partBrand = partBrands.FirstOrDefault(pb => pb.Id == partModel.PartBrandId);

                map.Add(new GetAllCarPartsQueryResponse
                {
                    Id = carPart.Id,
                    CarBrand = carBrand.BrandName, 
                    CarModel = carModel.ModelName,  
                    PartBrand = partBrand.BrandName,  
                    PartModel = partModel.ModelName  
                });
            }

            return map;
        }
    }
}
