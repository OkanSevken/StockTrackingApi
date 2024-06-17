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
            var carBrands = await unitOfWork.GetReadRepository<CarBrandModel>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var partBrands = await unitOfWork.GetReadRepository<PartBrandModel>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);

            List<GetAllCarPartsQueryResponse> map = new List<GetAllCarPartsQueryResponse>();

            foreach (var carPart in carParts)
            {
                var carBrandModel = carBrands.FirstOrDefault(w => w.Id == carPart.CarModelId);              
                var partBrandModel = partBrands.FirstOrDefault(p => p.Id == carPart.PartModelId);
         
                map.Add(new GetAllCarPartsQueryResponse
                {
                    Id = carPart.Id,
                    CarBrand = carBrandModel.Brand,
                    CarModel = carBrandModel.Model,
                    PartBrand = partBrandModel.Brand,
                    PartModel = partBrandModel.Model,
                });
            }
            return map;
        }
    }
}
