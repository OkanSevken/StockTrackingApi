using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartModels.Queries.GetListPartModelsFromBrand
{
    public class GetListPartModelsFromBrandQueryHandler : IRequestHandler<GetListPartModelsFromBrandQueryRequest, IList<GetListPartModelsFromBrandQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetListPartModelsFromBrandQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;   
        }
        public async Task<IList<GetListPartModelsFromBrandQueryResponse>> Handle(GetListPartModelsFromBrandQueryRequest request, CancellationToken cancellationToken)
        {
            var partModels = await unitOfWork.GetReadRepository<PartModel>().GetAllAsync(x => x.PartBrandId == request.Id && x.IsActive && !x.IsDeleted);       
            var partBrands = await unitOfWork.GetReadRepository<PartBrand>().GetAllAsync(x => x.IsActive && !x.IsDeleted);

            List<GetListPartModelsFromBrandQueryResponse> map = new List<GetListPartModelsFromBrandQueryResponse>();
            foreach (var partModel in partModels)
            {
                var partBrand = partBrands.FirstOrDefault(x => x.Id ==partModel.PartBrandId);
                map.Add(new GetListPartModelsFromBrandQueryResponse
                {
                    Id = partModel.Id,
                    ModelName=partModel.ModelName,
                    Year=partModel.Year,
                    PartBrandName=partBrand.BrandName
                });
            }
            return map;
        }
    }
}
