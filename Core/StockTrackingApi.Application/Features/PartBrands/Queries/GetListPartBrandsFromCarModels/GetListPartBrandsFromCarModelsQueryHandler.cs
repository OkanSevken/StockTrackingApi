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

namespace StockTrackingApi.Application.Features.PartBrands.Queries.GetListPartBrandsFromCarModels
{
    public class GetListPartBrandsFromCarModelsQueryHandler : IRequestHandler<GetListPartBrandsFromCarModelsQueryRequest, IList<GetListPartBrandsFromCarModelsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetListPartBrandsFromCarModelsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IList<GetListPartBrandsFromCarModelsQueryResponse>> Handle(GetListPartBrandsFromCarModelsQueryRequest request, CancellationToken cancellationToken)
        {
            var carParts = await unitOfWork.GetReadRepository<CarPart>().GetAllAsync(x =>x.CarModelId==request.Id  && x.IsActive && !x.IsDeleted);
            var partBrands = await unitOfWork.GetReadRepository<PartBrand>().GetAllAsync(x => x.IsActive && !x.IsDeleted);

            List<GetListPartBrandsFromCarModelsQueryResponse> map = new List<GetListPartBrandsFromCarModelsQueryResponse>();
            foreach (var carPart in carParts)
            {
                var partBrand = partBrands.FirstOrDefault(x => x.Id ==carPart.PartModelId);
                map.Add(new GetListPartBrandsFromCarModelsQueryResponse
                {
                    Id = carPart.Id,
                    PartBrandName=partBrand.BrandName
                });
            }
            return map;
        }
    }
}
