using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Queries.GetListPartMovementsFromInvoice
{
    public class GetListPartMovementsFromInvoiceQueryRequest : IRequest<IList<GetListPartMovementsFromInvoiceQueryResponse>>
    {
        public bool Invoice { get; set; }
    }
}
