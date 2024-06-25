using StockTrackingApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Domain.Entities
{
    public class PartModel : EntityBase
    {
        public PartModel() { }
        public PartModel(string modelName, int year, int partBrandId)
        {
            ModelName = modelName;
            Year = year;
            PartBrandId = partBrandId;
        }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public int PartBrandId { get; set; }

        public PartBrand PartBrand { get; set; }
    }
}
