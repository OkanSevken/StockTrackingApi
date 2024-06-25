using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartBrands.Queries.GetAllListPartBrands
{
    public class GetAllListPartBrandsQueryRequest : IRequest<IList<GetAllListPartBrandsQueryResponse>>
    {
    }
}
