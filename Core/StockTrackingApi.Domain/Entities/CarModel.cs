using StockTrackingApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Domain.Entities
{
    public class CarModel : EntityBase
    {
        public CarModel() { }
        public CarModel( string modelName, int year,int carBrandId)
        {
            ModelName = modelName;
            Year = year;
            CarBrandId = carBrandId;
        }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public int CarBrandId { get; set; }

        public CarBrand CarBrand { get; set; }
    }
}

