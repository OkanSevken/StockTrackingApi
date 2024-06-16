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

namespace StockTrackingApi.Application.Features.WarehouseParts.Command.UpdateWarehousePart
{
    public class UpdateWarehousePartCommandHandler : IRequestHandler<UpdateWarehousePartCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateWarehousePartCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateWarehousePartCommandRequest request, CancellationToken cancellationToken)
        {
            var warehousePart = await unitOfWork.GetReadRepository<WarehousePart>().GetAsync(x => x.Id == request.Id && x.IsActive == true && x.IsDeleted == false);

            var part = await unitOfWork.GetReadRepository<Part>().GetAsync(x => x.Id == request.PartId && x.IsActive == true && x.IsDeleted == false);

            // WarehousePart stok miktarını, Part tablosundaki stok miktarını geçmeyecek şekilde güncelle
            if (request.StockQuantity > part.Stock)
            {
                throw new InvalidOperationException("Fazla stok miktarı girdiniz");
            }

            warehousePart.WarehouseId = request.WarehouseId;
            warehousePart.PartId = request.PartId;
            warehousePart.StockQuantity = request.StockQuantity;
            warehousePart.LastModifyDate = DateTime.Now;     
            warehousePart.LastUserId = request.Id;


            await unitOfWork.GetWriteRepository<WarehousePart>().UpdateAsync(warehousePart);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }

    }
}
