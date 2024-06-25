using StockTrackingApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Domain.Entities
{
    public class PartBrand : EntityBase
    {
        public PartBrand() { }
        public PartBrand(string brandName)
        {
            BrandName = brandName;
        }
        public string BrandName { get; set; }
    }
}
