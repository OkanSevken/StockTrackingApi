using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartModels.Queries.GetListPartModelsFromBrand
{
    public class GetListPartModelsFromBrandQueryResponse
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int Year { get; set; }
        public string PartBrandName { get; set; }
    }
}
