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
            var model = await unitOfWork.GetReadRepository<PartBrandModel>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            List<GetAllPartsQueryResponse> map = new List<GetAllPartsQueryResponse>();

            foreach (var part in parts)
            {
                var modelName = model.FirstOrDefault(u => u.Id == part.ModelId).Model;
                var brandName = model.FirstOrDefault(u => u.Id == part.ModelId).Brand;
                map.Add(new GetAllPartsQueryResponse
                {
                    Id = part.Id,
                    Name = part.Name,
                    Description = part.Description,
                    BrandName = brandName,
                    ModelName = modelName,
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
