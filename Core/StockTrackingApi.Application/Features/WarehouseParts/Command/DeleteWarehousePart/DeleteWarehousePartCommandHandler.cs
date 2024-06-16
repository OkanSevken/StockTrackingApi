using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.WarehouseParts.Command.DeleteWarehousePart
{
    public class DeleteWarehousePartCommandHandler : IRequestHandler<DeleteWarehousePartCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DeleteWarehousePartCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteWarehousePartCommandRequest request, CancellationToken cancellationToken)
        {
            var warehouseParts = await unitOfWork.GetReadRepository<WarehousePart>().GetAsync(x => x.Id == request.Id && x.IsDeleted == false);

            warehouseParts.IsDeleted = true;
            warehouseParts.LastModifyDate = DateTime.Now;

            // var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            warehouseParts.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<WarehousePart>().UpdateAsync(warehouseParts);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
