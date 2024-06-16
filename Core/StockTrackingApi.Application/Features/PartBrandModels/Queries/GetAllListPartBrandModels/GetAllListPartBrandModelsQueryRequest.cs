using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartBrandModels.Queries.GetAllListPartBrandModels
{
    public class GetAllListPartBrandModelsQueryRequest : IRequest<IList<GetAllListPartBrandModelsQueryResponse>>
    {
    }
}
