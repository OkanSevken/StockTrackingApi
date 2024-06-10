using StockTrackingApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Domain.Entities
{
    public class WarehousePart : EntityBase
    {
        public WarehousePart() { }
        public WarehousePart(int warehouseId, int partId, int stockQuantity) 
        {
            WarehouseId = warehouseId;
            PartId = partId;
            StockQuantity = stockQuantity;
        }    
        public int WarehouseId { get; set; }
        public int PartId { get; set; }
        public int StockQuantity { get; set; }

        public Warehouse Warehouse { get; set; }
        public Part Part { get; set; }
    }
}
