using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Queries.GetListPartsFromCarBrand
{
    public class GetListPartsFromCarBrandQueryRequest : IRequest<IList<GetListPartsFromCarBrandQueryResponse>>
    {
        public string CarBrandName { get; set; }
    }
}
