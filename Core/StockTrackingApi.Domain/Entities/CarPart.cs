using StockTrackingApi.Domain.Cammon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Domain.Entities
{
    public class CarPart : EntityBase
    {
        public CarPart() { }
        public CarPart(int carmodelId, int partmodelId) 
        {
            CarModelId=carmodelId;
            PartModelId=partmodelId;
        }

        public int CarModelId { get; set; }
        public int PartModelId { get; set; }

        public CarModel CarModel { get; set; }
        public PartModel PartModel { get; set; }
    }
}
