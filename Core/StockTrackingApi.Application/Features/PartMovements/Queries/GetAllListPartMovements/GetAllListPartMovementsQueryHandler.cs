using MediatR;
using StockTrackingApi.Application.Features.WarehouseParts.Queries.GetAllListWarehouseParts;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Queries.GetAllListPartMovements
{
    public class GetAllListPartMovementsQueryHandler : IRequestHandler<GetAllListPartMovementsQueryRequest, IList<GetAllListPartMovementsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllListPartMovementsQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetAllListPartMovementsQueryResponse>> Handle(GetAllListPartMovementsQueryRequest request, CancellationToken cancellationToken)
        {
            var partMovements=await unitOfWork.GetReadRepository<PartMovement>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var warehouses = await unitOfWork.GetReadRepository<Warehouse>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);
            var parts = await unitOfWork.GetReadRepository<Part>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);

            List<GetAllListPartMovementsQueryResponse> map = new List<GetAllListPartMovementsQueryResponse>();

            foreach (var partMovement in partMovements)
            {
                var warehouse = warehouses.FirstOrDefault(w => w.Id == partMovement.WarehouseId)?.Name;
                var part = parts.FirstOrDefault(p => p.Id == partMovement.PartId)?.Name;

                map.Add(new GetAllListPartMovementsQueryResponse
                {
                    Id = partMovement.Id,
                    PartName = part,
                    WarehouseName = warehouse,
                    Amount = partMovement.Amount,
                    Price = partMovement.Price,
                    Invoice = partMovement.Invoice,
                    Date = partMovement.Date,
                    MovementType = partMovement.MovementType,
                    Description = partMovement.Description,
                });
            }

            return map;
        }
    }
}
