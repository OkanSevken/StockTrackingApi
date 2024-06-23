using MediatR;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Warehouses.Queries.GetListWarehouseFromPart
{
    public class GetListWarehouseFromPartQueryHandler : IRequestHandler<GetListWarehouseFromPartQueryRequest, IList<GetListWarehouseFromPartQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetListWarehouseFromPartQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }
        public async Task<IList<GetListWarehouseFromPartQueryResponse>> Handle(GetListWarehouseFromPartQueryRequest request, CancellationToken cancellationToken)
        {
            var warehousesParts = await unitOfWork.GetReadRepository<WarehousePart>().GetAllAsync(x => x.PartId == request.PartId && x.IsActive == true && x.IsDeleted == false);
            var warehouses = await unitOfWork.GetReadRepository<Warehouse>().GetAllAsync();

            List<GetListWarehouseFromPartQueryResponse> map = new List<GetListWarehouseFromPartQueryResponse>();
            foreach (var warehousesPart in warehousesParts)
            {
                var warehouse = warehouses.FirstOrDefault(x=>x.Id == warehousesPart.WarehouseId);

                map.Add(new GetListWarehouseFromPartQueryResponse
                {
                    Id = warehouse.Id,
                    WarehouseName = warehouse.Name,
                });
            }
            return map;
        }
    }
}
