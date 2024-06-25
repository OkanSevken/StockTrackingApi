using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartBrands.Queries.GetAllListPartBrands
{
    public class GetAllListPartBrandsQueryHandler : IRequestHandler<GetAllListPartBrandsQueryRequest, IList<GetAllListPartBrandsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllListPartBrandsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllListPartBrandsQueryResponse>> Handle(GetAllListPartBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var partBrands = await unitOfWork.GetReadRepository<PartBrand>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);

            var map = mapper.Map<GetAllListPartBrandsQueryResponse, PartBrand>(partBrands);

            return map;
        }
    }
}
