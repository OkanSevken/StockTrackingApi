using MediatR;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Queries.GetListPartsFromBrand
{
    public class GetListPartsFromBrandQueryHandler : IRequestHandler<GetListPartsFromBrandQueryRequest, IList<GetListPartsFromBrandQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        //private readonly IMapper mapper;

        public GetListPartsFromBrandQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public async Task<IList<GetListPartsFromBrandQueryResponse>> Handle(GetListPartsFromBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var parts = await unitOfWork.GetReadRepository<Part>().GetAllAsync(x => x.PartModelId==request.Id && x.IsActive && !x.IsDeleted);
            var partModels = await unitOfWork.GetReadRepository<PartModel>().GetAllAsync(x =>x.IsActive == true && !x.IsDeleted);


            List<GetListPartsFromBrandQueryResponse> map = new List<GetListPartsFromBrandQueryResponse>();

            foreach (var part in parts)
            {
                var partModel = partModels.FirstOrDefault(x => x.Id == part.PartModelId);
            
                    map.Add(new GetListPartsFromBrandQueryResponse
                    {
                        Id = part.Id,
                        PartName= partModel.ModelName,
                    });                
            }

            return map;
        }

    }
}


//  ------------ModelId'ye göre arama yapmak için ---------

//var parts = await unitOfWork.GetReadRepository<Part>().GetAllAsync(x => x.IsActive && !x.IsDeleted && x.ModelId == request.ModelId);
//var partModels = await unitOfWork.GetReadRepository<PartBrandModel>().GetAllAsync(x => x.IsActive && !x.IsDeleted);


//var partModel = partModels.FirstOrDefault(x => x.Id == request.ModelId);

//List<GetListPartsFromBrandQueryResponse> map = new List<GetListPartsFromBrandQueryResponse>();

//foreach (var part in parts)
//{
//    map.Add(new GetListPartsFromBrandQueryResponse
//    {
//        Id = part.Id,
//        Name = part.Name,
//        Description = part.Description,
//        PurchasePrice = part.PurchasePrice,
//        SalePrice = part.SalePrice,
//        Vat = part.Vat,
//        Stock = part.Stock,
//        Profit = part.Profit,
//        Invoice = part.Invoice,
//        BrandName = partModel.Brand,
//        ModelName = partModel.Model
//    });
//}
//return map;