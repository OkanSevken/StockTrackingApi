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

namespace StockTrackingApi.Application.Features.Warehouses.Command.UpdateWarehouse
{
    public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateWarehouseCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateWarehouseCommandRequest request, CancellationToken cancellationToken)
        {
            var warehouses = await unitOfWork.GetReadRepository<Warehouse>().GetAsync(x => x.Id == request.Id && x.IsActive == true && x.IsDeleted == false);
            
            warehouses.Name = request.Name;
            warehouses.Address = request.Address;

            warehouses.LastModifyDate = DateTime.Now;

            // var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            warehouses.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<Warehouse>().UpdateAsync(warehouses);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
