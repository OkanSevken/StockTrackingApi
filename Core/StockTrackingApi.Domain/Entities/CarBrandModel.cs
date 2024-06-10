using StockTrackingApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Domain.Entities
{
    public class CarBrandModel : EntityBase
    {
        public CarBrandModel() { }
        public CarBrandModel(string brand, string model, int year) 
        {
            Brand = brand;
            Model = model;
            Year = year;
        }    
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
