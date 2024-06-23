using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Warehouses.Queries.GetListWarehouseFromPart
{
    public class GetListWarehouseFromPartQueryResponse
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
    }
}
