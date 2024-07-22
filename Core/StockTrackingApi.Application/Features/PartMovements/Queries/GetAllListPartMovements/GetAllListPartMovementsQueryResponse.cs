using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Queries.GetAllListPartMovements
{
    public class GetAllListPartMovementsQueryResponse
    {
        public int Id { get; set; }
        public string PartName{ get; set; }
        public string PartCode { get; set; }
        public string WarehouseName { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public bool Invoice { get; set; }
        public DateTime Date { get; set; }
        public string MovementType { get; set; } 
        public string Description { get; set; }
    }
}
