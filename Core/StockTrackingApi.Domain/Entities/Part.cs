using StockTrackingApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Domain.Entities
{
    public class Part : EntityBase
    {
        public Part() { }

        public Part(string name, string description, float purchasePrice, float salePrice ,float vat, int stock, bool invoice,int modelId) 
        {
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;
            Vat = vat;
            Stock = stock;
            Invoice = invoice;
            ModelId = modelId;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; }
        public float Vat { get; set; }
        public int Stock { get; set; }
        public float Profit { get; set; }
        public bool Invoice { get; set; }
        public float VatPaid { get; set; }
        public int ModelId { get; set; } //PartBrandModel'in id'si
       // public ICollection<WarehousePart> WarehouseParts { get; set; }

        public PartBrandModel PartBrandModel { get; set; }


       
    }
}
