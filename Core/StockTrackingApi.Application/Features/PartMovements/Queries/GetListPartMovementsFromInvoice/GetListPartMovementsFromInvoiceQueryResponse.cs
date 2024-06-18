using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Queries.GetListPartMovementsFromInvoice
{
    public class GetListPartMovementsFromInvoiceQueryResponse
    {
        public int PartId { get; set; }
        public string PartName { get; set; }
    }
}
