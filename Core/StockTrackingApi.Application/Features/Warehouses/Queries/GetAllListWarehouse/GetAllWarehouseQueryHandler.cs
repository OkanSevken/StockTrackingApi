using MediatR;
using StockTrackingApi.Application.Features.Parts.Queries.GetAllListParts;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Warehouses.Queries.GetAllListWarehouse
{
    public class GetAllWarehouseQueryHandler : IRequestHandler<GetAllWarehouseQueryRequest, IList<GetAllWarehouseQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllWarehouseQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllWarehouseQueryResponse>> Handle(GetAllWarehouseQueryRequest request, CancellationToken cancellationToken)
        {
            var warehouses= await unitOfWork.GetReadRepository<Warehouse>().GetAllAsync(x=>x.IsActive==true && x.IsDeleted==false);

            List<GetAllWarehouseQueryResponse> map = new List<GetAllWarehouseQueryResponse>();

            foreach (var warehouse in warehouses)
            {
                map.Add(new GetAllWarehouseQueryResponse
                {
                    Id = warehouse.Id,
                    Name = warehouse.Name,
                    Address = warehouse.Address
                });
            }
            return map;
        }
    }
}
