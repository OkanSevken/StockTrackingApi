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
        public WarehousePart(int warehouseId, int partId) 
        {
            WarehouseId = warehouseId;
            PartId = partId;
        }    
        public int WarehouseId { get; set; }
        public int PartId { get; set; }
        public int StockQuantity { get; set; }= 0;

        public Warehouse Warehouse { get; set; }
        public Part Part { get; set; }
    }
}
