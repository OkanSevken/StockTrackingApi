using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.WarehouseParts.Queries.GetAllListWarehouseParts
{
    public class GetAllWarehousePartsQueryResponse
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int PartId { get; set; }
        public string PartName { get; set; }
        public int StockQuantity { get; set; }
    }
}
