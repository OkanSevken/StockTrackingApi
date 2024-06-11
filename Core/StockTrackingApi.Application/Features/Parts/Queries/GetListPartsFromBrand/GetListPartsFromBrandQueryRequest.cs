using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Queries.GetListPartsFromBrand
{
    public class GetListPartsFromBrandQueryRequest : IRequest<IList<GetListPartsFromBrandQueryResponse>>
    {
        public string BrandName { get; set; }
    }
}
