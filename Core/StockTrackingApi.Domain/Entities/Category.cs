using StockTrackingApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category() { }
        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }
        public string CategoryName { get; set; }
    }
}
