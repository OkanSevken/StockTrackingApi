using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Warehouses.Command.DeleteWarehouse
{
    public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DeleteWarehouseCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteWarehouseCommandRequest request, CancellationToken cancellationToken)
        {
            var warehouses = await unitOfWork.GetReadRepository<Warehouse>().GetAsync(x => x.Id == request.Id && x.IsDeleted == false);

            warehouses.IsDeleted = true;
            warehouses.LastModifyDate = DateTime.Now;

            warehouses.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<Warehouse>().UpdateAsync(warehouses);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
