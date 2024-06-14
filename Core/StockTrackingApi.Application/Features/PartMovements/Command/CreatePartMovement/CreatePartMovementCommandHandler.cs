using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Command.CreatePartMovement
{
    public class CreatePartMovementCommandHandler : IRequestHandler<CreatePartMovementCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreatePartMovementCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreatePartMovementCommandRequest request, CancellationToken cancellationToken)
        {

            var part = await unitOfWork.GetReadRepository<Part>().GetAsync(x => x.Id == request.PartId);
            
            var warehousePart = await unitOfWork.GetReadRepository<WarehousePart>().GetAsync(x => x.PartId == request.PartId && x.WarehouseId == request.WarehouseId);

            var transaction = new PartMovement
            {
                PartId = request.PartId,
                WarehouseId = request.WarehouseId,
                Amount = request.Amount,
                Date = DateTime.Now,
                MovementType = request.MovementType,
                Description = request.Description,
                CreaterUserId=1
            };

            if (request.MovementType == "Giris")
            {
                part.Stock += request.Amount;
                warehousePart.StockQuantity += request.Amount;
            }
            else if (request.MovementType == "Cikis")
            {
                if (part.Stock < request.Amount || warehousePart.StockQuantity < request.Amount)
                {
                    throw new Exception("Yetersiz Stok");
                }

                part.Stock -= request.Amount;
                warehousePart.StockQuantity -= request.Amount;
            }
          

            float profit = part.Stock * (part.SalePrice - part.PurchasePrice);
            float vatPaid = part.Stock * ((part.SalePrice * part.Vat / 100) - (part.PurchasePrice * part.Vat / 100));

            part.Profit = profit;
            part.VatPaid = vatPaid;

            await unitOfWork.GetWriteRepository<Part>().UpdateAsync(part);
            await unitOfWork.GetWriteRepository<WarehousePart>().UpdateAsync(warehousePart);

            await unitOfWork.GetWriteRepository<PartMovement>().AddAsync(transaction);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
