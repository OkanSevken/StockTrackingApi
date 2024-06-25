using MediatR;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Queries.GetAllListParts
{
    public class GetAllPartsQueryHandler : IRequestHandler<GetAllPartsQueryRequest, IList<GetAllPartsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        //private readonly IMapper mapper;

        public GetAllPartsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public async Task<IList<GetAllPartsQueryResponse>> Handle(GetAllPartsQueryRequest request, CancellationToken cancellationToken)
        {
            var parts = await unitOfWork.GetReadRepository<Part>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var partModels = await unitOfWork.GetReadRepository<PartModel>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var carModels = await unitOfWork.GetReadRepository<CarModel>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var partBrands = await unitOfWork.GetReadRepository<PartBrand>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var carBrands = await unitOfWork.GetReadRepository<CarBrand>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            List<GetAllPartsQueryResponse> map = new List<GetAllPartsQueryResponse>();

            foreach (var part in parts)
            {
                var partModel = partModels.FirstOrDefault(pm => pm.Id == part.PartModelId);
                var partBrand = partBrands.FirstOrDefault(pb => pb.Id == partModel.PartBrandId);
                var carModel = carModels.FirstOrDefault(cm => cm.Id == partModel.PartBrandId);
                var carBrand = carBrands.FirstOrDefault(cb => cb.Id == carModel.CarBrandId);
                map.Add(new GetAllPartsQueryResponse
                {
                    Id = part.Id,
                    Name = part.Name,
                    Description = part.Description,
                    CarBrandName = carBrand.BrandName,
                    CarModelName = carModel.ModelName,
                    PartBrandName = partBrand.BrandName,
                    PartModelName = partModel.ModelName,
                    PurchasePrice = part.PurchasePrice,
                    SalePrice = part.SalePrice,
                    Vat = part.Vat,
                    VatPaid = part.VatPaid,
                    Stock = part.Stock,
                    Profit = part.Profit,
                });
            }
            return map;
        }
    }
}
