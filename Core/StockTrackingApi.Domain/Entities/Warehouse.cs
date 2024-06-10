using StockTrackingApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Domain.Entities
{
    public class Warehouse : EntityBase
    {
        public Warehouse() { }
        public Warehouse(string name, string address) 
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; set; }

        //public ICollection<WarehousePart> WarehouseParts { get; set; }

    }
}
