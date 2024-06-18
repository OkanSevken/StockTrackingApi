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
            bool oldInvoice = partMovements.Invoice;
            int oldPrice = partMovements.Price;

            int newAmount = request.Amount;
            string newMovementType = request.MovementType;
            bool newInvoice = request.Invoice;
            int newPrice = request.Price;

            // Eski hareketin etkilerini geri al
            if (oldMovementType == "Giris")
            {
                parts.Stock -= oldAmount;
                warehouseParts.StockQuantity -= oldAmount;
                parts.Profit += oldAmount * oldPrice;
                if (oldInvoice)
                {
                    parts.VatPaid += oldAmount * (oldPrice * parts.Vat / 100);
                }
            }
            else if (oldMovementType == "Cikis")
            {
                parts.Stock += oldAmount;
                warehouseParts.StockQuantity += oldAmount;
                parts.Profit -= oldAmount * oldPrice;
                if (oldInvoice)
                {
                    parts.VatPaid -= oldAmount * (oldPrice * parts.Vat / 100);
                }
            }

            // Yeni hareketin etkilerini uygula
            if (newMovementType == "Giris")
            {
                parts.Stock += newAmount;
                warehouseParts.StockQuantity += newAmount;
                parts.PurchasePrice = newPrice;
                parts.Profit -= newAmount * newPrice;
                if (newInvoice)
                {
                    parts.VatPaid -= newAmount * (newPrice * parts.Vat / 100);
                }
            }
            else if (newMovementType == "Cikis")
            {
                if (parts.Stock < newAmount || warehouseParts.StockQuantity < newAmount)
                {
                    throw new Exception("Yetersiz Stok");
                }

                parts.Stock -= newAmount;
                warehouseParts.StockQuantity -= newAmount;
                parts.SalePrice = newPrice;
                parts.Profit += newAmount * newPrice;
                if (newInvoice)
                {
                    parts.VatPaid += newAmount * (newPrice * parts.Vat / 100);
                }
            }
            // PartMovement kaydı
            partMovements.Amount = newAmount;
            partMovements.Price=request.Price;
            partMovements.Invoice=request.Invoice;
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
