using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Command.UpdatePart
{
    public class UpdatePartCommandHandler : IRequestHandler<UpdatePartCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdatePartCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdatePartCommandRequest request, CancellationToken cancellationToken)
        {
            var parts = await unitOfWork.GetReadRepository<Part>().GetAsync(x=>x.Id==request.Id && x.IsActive==true && x.IsDeleted==false);

            parts.Name = request.Name;
            parts.Description = request.Description;
            parts.PurchasePrice = request.PurchasePrice;
            parts.SalePrice = request.SalePrice;
            parts.Vat=request.Vat;
            parts.Stock=request.Stock;

            parts.LastModifyDate = DateTime.Now;

            // var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            parts.LastUserId = request.Id;

            float profit = request.Stock * (request.SalePrice - request.PurchasePrice);
            float vatPaid = request.Stock * ((request.SalePrice * request.Vat / 100) - (request.PurchasePrice * request.Vat / 100));

            parts.Profit = profit;
            parts.VatPaid = vatPaid;

            await unitOfWork.GetWriteRepository<Part>().UpdateAsync(parts);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
