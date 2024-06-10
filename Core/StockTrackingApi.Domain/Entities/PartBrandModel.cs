using StockTrackingApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Domain.Entities
{
    public class PartBrandModel : EntityBase
    {
        public PartBrandModel() { }
        public PartBrandModel(string brand, string model, string category) 
        {
            Brand = brand;
            Model = model;
            Category = category;
        }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
    }
}
