using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.WarehouseParts.Command.CreateWarehousePart
{
    public class CreateWarehousePartCommandHandler : IRequestHandler<CreateWarehousePartCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateWarehousePartCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateWarehousePartCommandRequest request, CancellationToken cancellationToken)
        {
            var part = await unitOfWork.GetReadRepository<Part>().GetAsync(x => x.Id == request.PartId && x.IsActive == true && x.IsDeleted == false);

            // WarehousePart stok miktarını, Part tablosundaki stok miktarını geçmeyecek şekilde güncelle
            if (request.StockQuantity > part.Stock)
            {
                throw new InvalidOperationException("Fazla stok miktarı girdiniz");
            }
            WarehousePart warehousePart = new
                (
                    request.WarehouseId,
                    request.PartId,
                    request.StockQuantity
                );
            warehousePart.CreatedDate = DateTime.Now;
            warehousePart.CreaterUserId = 1;
            warehousePart.IsActive = true;
            warehousePart.IsDeleted = false;


            await unitOfWork.GetWriteRepository<WarehousePart>().AddAsync(warehousePart);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
