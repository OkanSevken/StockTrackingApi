using MediatR;
using StockTrackingApi.Application.Features.PartBrands.Queries.GetAllListPartBrands;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarBrands.Queries.GetAllListCarBrands
{
    public class GetAllListPartBrandsQueryHandler : IRequestHandler<GetAllListCarBrandsQueryRequest, IList<GetAllListCarBrandsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllListPartBrandsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllListCarBrandsQueryResponse>> Handle(GetAllListCarBrandsQueryRequest request, CancellationToken cancellationToken)
        {
            var carBrands = await unitOfWork.GetReadRepository<CarBrand>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);

            var map = mapper.Map<GetAllListCarBrandsQueryResponse, CarBrand>(carBrands);
            return map;
        }
    }
}
