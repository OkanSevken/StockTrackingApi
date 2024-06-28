using MediatR;
using StockTrackingApi.Application.Features.Parts.Queries.GetAllListParts;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Queries.GetListPart
{
    public class GetListPartQueryHandler : IRequestHandler<GetListPartQueryRequest, IList<GetListPartQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetListPartQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetListPartQueryResponse>> Handle(GetListPartQueryRequest request, CancellationToken cancellationToken)
        {
            var parts = await unitOfWork.GetReadRepository<Part>().GetAsync(x => x.Id == request.Id && x.IsActive == true && x.IsDeleted == false);
            var partModels = await unitOfWork.GetReadRepository<PartModel>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var carModels = await unitOfWork.GetReadRepository<CarModel>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var partBrands = await unitOfWork.GetReadRepository<PartBrand>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var carBrands = await unitOfWork.GetReadRepository<CarBrand>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);



            var partModel = partModels.FirstOrDefault(pm => pm.Id == parts?.PartModelId);
            var carModel = carModels.FirstOrDefault(cm => cm.Id == parts?.CarModelId);
            var partBrand = partBrands.FirstOrDefault(pb => pb.Id == partModel?.PartBrandId);
            var carBrand = carBrands.FirstOrDefault(cb => cb.Id == carModel?.CarBrandId);
            var category = categories.FirstOrDefault(c => c.Id == parts?.CategoryId);
            List<GetListPartQueryResponse> map = new List<GetListPartQueryResponse>();

            map.Add(new GetListPartQueryResponse
            {
                Id = parts.Id,
                Name = parts.Name,
                PartCode = parts.PartCode,
                CarBrandName = carBrand?.BrandName,
                CarModelName = carModel?.ModelName,
                PartBrandName = partBrand?.BrandName,
                PartModelName = partModel?.ModelName,
                PartModelYear=partModel.Year,
                CategoryName = category?.CategoryName,
                PurchasePrice = parts.PurchasePrice,
                SalePrice = parts.SalePrice,
                Vat = parts.Vat,
                VatPaid = parts.VatPaid,
                Stock = parts.Stock,
                Profit = parts.Profit,
            });

            return map;
        }
    }

}
