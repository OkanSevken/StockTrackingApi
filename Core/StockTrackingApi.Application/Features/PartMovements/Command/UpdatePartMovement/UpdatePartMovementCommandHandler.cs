using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Command.UpdatePartMovement
{
    public class UpdatePartMovementCommandHandler : IRequestHandler<UpdatePartMovementCommandRequest,Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdatePartMovementCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePartMovementCommandRequest request, CancellationToken cancellationToken)
        {
            var partMovements = await unitOfWork.GetReadRepository<PartMovement>().GetAsync(x => x.Id == request.Id && x.IsActive == true && x.IsDeleted == false);
            var parts = await unitOfWork.GetReadRepository<Part>().GetAsync(x => x.Id == partMovements.PartId && x.IsActive == true && x.IsDeleted == false);
            var warehouseParts = await unitOfWork.GetReadRepository<WarehousePart>().GetAsync(x => x.PartId == partMovements.PartId && x.WarehouseId == partMovements.WarehouseId && x.IsActive == true && x.IsDeleted == false);
            
            int oldAmount = partMovements.Amount;
            string oldMovementType = partMovements.MovementType;


            int newAmount = request.Amount;
            string newMovementType = request.MovementType;

            // Part ve WarehousePart stok miktarlarını ilk haline getir
            if (oldMovementType == "Giris")
            {
                parts.Stock -= oldAmount;
                warehouseParts.StockQuantity -= oldAmount;
            }
            else if (oldMovementType == "Cikis")
            {
                parts.Stock += oldAmount;
                warehouseParts.StockQuantity += oldAmount;
            }
            // Part ve WarehousePart için yeni stok miktarlarını güncelle
            if (newMovementType == "Giris")
            {
                parts.Stock += newAmount;
                warehouseParts.StockQuantity += newAmount;
            }
            else if (newMovementType == "Cikis")
            {
                parts.Stock -= newAmount;
                warehouseParts.StockQuantity -= newAmount;
            }


            parts.Profit = parts.Stock * (parts.SalePrice - parts.PurchasePrice);
            parts.VatPaid = parts.Stock * ((parts.SalePrice * parts.Vat / 100) - (parts.PurchasePrice * parts.Vat / 100));

            // PartMovement kaydı
            partMovements.Amount = newAmount;
            partMovements.MovementType = newMovementType;
            partMovements.Description = request.Description;
            partMovements.Date = DateTime.Now;
            partMovements.LastModifyDate = DateTime.Now;
            partMovements.LastUserId = request.Id;

            //Part kaydı 
            parts.LastModifyDate= DateTime.Now;
            parts.LastUserId = request.Id;
            
            //WarehousePart kaydı
            warehouseParts.LastModifyDate=DateTime.Now;
            warehouseParts.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<PartMovement>().UpdateAsync(partMovements);
            await unitOfWork.GetWriteRepository<Part>().UpdateAsync(parts);
            await unitOfWork.GetWriteRepository<WarehousePart>().UpdateAsync(warehouseParts);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
