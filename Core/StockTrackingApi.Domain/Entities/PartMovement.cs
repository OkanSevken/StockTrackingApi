using StockTrackingApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Domain.Entities
{
    public class PartMovement : EntityBase
    {
        public PartMovement() { }

        public PartMovement(int partId, int warehouseId, int amount,int price,bool invoice ,DateTime date, string movementType, string description) 
        {
            PartId = partId;
            WarehouseId = warehouseId;
            Amount = amount;
            Price = price;
            Invoice = invoice;
            Date = date;
            MovementType = movementType;
            Description = description;
        }

        public int PartId { get; set; }
        public int WarehouseId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public bool Invoice { get; set; }
        public DateTime Date { get; set; }
        public string MovementType { get; set; } //Giris veya çıkış
        public string Description { get; set; }

        public Part Part { get; set; }
        public Warehouse Warehouse { get; set; }
        

    }
}
