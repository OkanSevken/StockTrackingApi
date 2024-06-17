﻿using StockTrackingApi.Domain.Cammon;
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

        public Part(string name, string description, float purchasePrice ,float vat, int modelId) 
        {
            Name = name;
            Description = description;
            PurchasePrice = purchasePrice;
            //SalePrice = salePrice;
            Vat = vat;
            //Stock = stock;
            ModelId = modelId;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; } = 0;
        public float Vat { get; set; }
        public int Stock { get; set; }=0;
        public float Profit { get; set; }=0;
        public float VatPaid { get; set; } = 0;
        public int ModelId { get; set; } //PartBrandModel'in id'si
       // public ICollection<WarehousePart> WarehouseParts { get; set; }

        public PartBrandModel PartBrandModel { get; set; }


       
    }
}
