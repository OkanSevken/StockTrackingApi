using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Command.CreatePart
{
    public class CreatePartCommandHandler : IRequestHandler<CreatePartCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreatePartCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreatePartCommandRequest request, CancellationToken cancellationToken)
        {
           // float profit = request.Stock * (request.SalePrice - request.PurchasePrice);
            //float vatPaid = request.Stock * ((request.SalePrice * request.Vat / 100) - (request.PurchasePrice * request.Vat / 100));

            Part part = new
            (
                request.Name,
                request.Description,
                request.PurchasePrice,
                request.Vat,
                request.CategoryId,
                request.PartModelId
            );
            part.CreatedDate = DateTime.Now;
            part.CreaterUserId = 1;
            part.IsActive = true;
            part.IsDeleted = false;
            //part.Profit=-(request.PurchasePrice)*(request.Stock);
            //part.VatPaid= request.Stock*((request.PurchasePrice) * (request.Vat/100));
            // part.Profit = profit;
            // part.VatPaid = vatPaid;

            await unitOfWork.GetWriteRepository<Part>().AddAsync(part);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
