using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Warehouses.Queries.GetListWarehouseFromPart
{
    public class GetListWarehouseFromPartQueryRequest : IRequest<IList<GetListWarehouseFromPartQueryResponse>>
    {
        public int PartId { get; set; }
    }
}
