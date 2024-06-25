using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarModels.Queries.GetListCarModelsFromBrand
{
    public class GetListCarModelsFromBrandQueryResponse
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public string CarBrandName { get; set; }

    }
}
