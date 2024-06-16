using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarBrandModels.Queries.GetAllListCarBrandModels
{
    public class GetAllListCarBrandModelsQueryRequest : IRequest<IList<GetAllListCarBrandModelsQueryResponse>>
    {
    }
}
