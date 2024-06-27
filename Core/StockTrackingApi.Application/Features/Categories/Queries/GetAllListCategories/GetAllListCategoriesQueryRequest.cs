using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Categories.Queries.GetAllListCategories
{
    public class GetAllListCategoriesQueryRequest : IRequest<IList<GetAllListCategoriesQueryResponse>>
    {
    }
}
