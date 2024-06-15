using MediatR;
using StockTrackingApi.Application.Features.Parts.Queries.GetAllListParts;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.WarehouseParts.Queries.GetAllListWarehouseParts
{
    public class GetAllWarehousePartsQueryHandler : IRequestHandler<GetAllWarehousePartsQueryRequest, IList<GetAllWarehousePartsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllWarehousePartsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllWarehousePartsQueryResponse>> Handle(GetAllWarehousePartsQueryRequest request, CancellationToken cancellationToken)
        {
            var warehouseParts = await unitOfWork.GetReadRepository<WarehousePart>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var warehouses = await unitOfWork.GetReadRepository<Warehouse>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var parts = await unitOfWork.GetReadRepository<Part>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);

            List<GetAllWarehousePartsQueryResponse> map = new List<GetAllWarehousePartsQueryResponse>();

            foreach (var warehousePart in warehouseParts)
            {
                var warehouse = warehouses.FirstOrDefault(w => w.Id == warehousePart.WarehouseId).Name;
                var part = parts.FirstOrDefault(p => p.Id == warehousePart.PartId).Name;

                    map.Add(new GetAllWarehousePartsQueryResponse
                    {
                        Id = warehousePart.Id,
                        WarehouseName = warehouse,
                        PartName = part,
                        StockQuantity = warehousePart.StockQuantity
                    });    
            }

            return map;
        }
    }
}
