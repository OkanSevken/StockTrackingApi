using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarBrands.Queries.GetAllListCarBrands
{
    public class GetAllListCarBrandsQueryResponse
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
    }
}
