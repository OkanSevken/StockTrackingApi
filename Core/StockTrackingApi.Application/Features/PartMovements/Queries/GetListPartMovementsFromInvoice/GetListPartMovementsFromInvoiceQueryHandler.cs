using MediatR;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Queries.GetListPartMovementsFromInvoice
{
    public class GetListPartMovementsFromInvoiceQueryHandler : IRequestHandler<GetListPartMovementsFromInvoiceQueryRequest, IList<GetListPartMovementsFromInvoiceQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetListPartMovementsFromInvoiceQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GetListPartMovementsFromInvoiceQueryResponse>> Handle(GetListPartMovementsFromInvoiceQueryRequest request, CancellationToken cancellationToken)
        {
            var invoices = await unitOfWork.GetReadRepository<PartMovement>().GetAllAsync(x => x.Invoice == request.Invoice && x.IsActive == true && x.IsDeleted == false);
            var parts = await unitOfWork.GetReadRepository<Part>().GetAllAsync(x => x.IsActive==true && x.IsDeleted==false);

            List<GetListPartMovementsFromInvoiceQueryResponse> map = new List<GetListPartMovementsFromInvoiceQueryResponse>();

            foreach (var invoice in invoices)
            {
                var partInvoice = parts.FirstOrDefault(x => x.Id == invoice.PartId);

                map.Add(new GetListPartMovementsFromInvoiceQueryResponse
                {
                    PartId=partInvoice.Id,
                    PartName = partInvoice.Name,
                });
            }
            return map;
        }
    }
}
