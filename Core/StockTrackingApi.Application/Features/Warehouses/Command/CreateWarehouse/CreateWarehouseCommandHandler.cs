using MediatR;
using StockTrackingApi.Application.Features.Parts.Queries.GetAllListParts;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Warehouses.Command.CreateWarehouse
{
    public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommandRequest, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateWarehouseCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateWarehouseCommandRequest request, CancellationToken cancellationToken)
        {
            Warehouse warehouse = new
                (
                    request.Name,
                    request.Address
                );
            warehouse.CreatedDate = DateTime.Now;
            warehouse.CreaterUserId = 1;
            warehouse.IsActive = true;
            warehouse.IsDeleted = false;

            await unitOfWork.GetWriteRepository<Warehouse>().AddAsync(warehouse);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
