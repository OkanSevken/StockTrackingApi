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

namespace StockTrackingApi.Application.Features.PartModels.Queries.GetListPartModelsFromModel
{
    public class GetListPartModelsFromModelQueryHandler : IRequestHandler<GetListPartModelsFromModelQueryRequest, IList<GetListPartModelsFromModelQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetListPartModelsFromModelQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetListPartModelsFromModelQueryResponse>> Handle(GetListPartModelsFromModelQueryRequest request, CancellationToken cancellationToken)
        {
            var partModels = await unitOfWork.GetReadRepository<PartModel>().GetAllAsync(x => x.Id == request.Id && x.IsActive && !x.IsDeleted);
            var partBrands = await unitOfWork.GetReadRepository<PartBrand>().GetAllAsync(x => x.IsActive && !x.IsDeleted);
            
            List<GetListPartModelsFromModelQueryResponse> map = new List<GetListPartModelsFromModelQueryResponse>();
            foreach (var partModel in partModels)
            {
                var partBrand = partBrands.FirstOrDefault(x => x.Id == partModel.PartBrandId);
                map.Add(new GetListPartModelsFromModelQueryResponse
                {
                    Id = partModel.Id,
                    ModelName = partModel.ModelName,
                    Year = partModel.Year,
                    PartBrandName = partBrand.BrandName
                });
            }
            return map;
        }
    }
}
