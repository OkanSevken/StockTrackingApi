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

        public Part(string name, string partCode, float purchasePrice ,float vat, int categoryId,int partModelId,int carModelId) 
        {
            Name = name;
            PartCode = partCode;
            PurchasePrice = purchasePrice;
            //SalePrice = salePrice;
            Vat = vat;
            //Stock = stock;
            CategoryId = categoryId;
            PartModelId = partModelId;
            CarModelId = carModelId;
        }
        public string Name { get; set; }
        public string PartCode { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; } = 0;
        public float Vat { get; set; }
        public int Stock { get; set; }=0;
        public float Profit { get; set; }=0;
        public float VatPaid { get; set; } = 0;
        public int CategoryId { get; set; }
        public int PartModelId { get; set; }
        public int? CarModelId { get; set; }
        //public int ModelId { get; set; } //PartBrandModel'in id'si
        // public ICollection<WarehousePart> WarehouseParts { get; set; }

        public Category Category { get; set; }
        public PartModel PartModel { get; set; }
        public CarModel CarModel{ get; set; }



    }
}
