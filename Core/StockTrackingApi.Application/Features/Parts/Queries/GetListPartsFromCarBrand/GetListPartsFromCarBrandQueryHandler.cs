using MediatR;
using StockTrackingApi.Application.Features.Parts.Queries.GetListPartsFromBrand;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Queries.GetListPartsFromCarBrand
{
    public class GetListPartsFromCarBrandQueryHandler : IRequestHandler<GetListPartsFromCarBrandQueryRequest, IList<GetListPartsFromCarBrandQueryResponse>>
    {

        private readonly IUnitOfWork unitOfWork;
      

        public GetListPartsFromCarBrandQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public async Task<IList<GetListPartsFromCarBrandQueryResponse>> Handle(GetListPartsFromCarBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var parts = await unitOfWork.GetReadRepository<Part>().GetAllAsync(x => x.IsActive && !x.IsDeleted);
            var carBrands = await unitOfWork.GetReadRepository<CarBrandModel>().GetAllAsync(x => x.Brand == request.CarBrandName && x.IsActive && !x.IsDeleted);

            List<GetListPartsFromCarBrandQueryResponse> map = new List<GetListPartsFromCarBrandQueryResponse>();

            foreach (var carBrand in carBrands)
            {
                var carParts = await unitOfWork.GetReadRepository<CarPart>().GetAllAsync(x => x.CarModelId == carBrand.Id);

                foreach (var part in parts)
                {
                    var carPart = carParts.FirstOrDefault(x => x.PartModelId == part.ModelId);

                    if (carPart != null)
                    {
                        map.Add(new GetListPartsFromCarBrandQueryResponse
                        {
                            PartId = part.Id,
                            Name = part.Name,
                            Description = part.Description,
                            PurchasePrice = part.PurchasePrice,
                            SalePrice = part.SalePrice,
                            Vat = part.Vat,
                            VatPaid = part.VatPaid,
                            Stock = part.Stock,
                            Profit = part.Profit,
                            BrandName = carBrand.Brand,
                            ModelName = carBrand.Model
                        });
                    }
                }
            }
            return map;
        }
    }
}
