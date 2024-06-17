using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarParts.Queries.GetAllListCarParts
{
    public class GetAllCarPartsQueryResponse
    {
        public int Id { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string PartBrand { get; set; }
        public string PartModel { get; set; }
    }
}
