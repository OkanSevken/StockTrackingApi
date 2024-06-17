using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarParts.Queries.GetAllListCarParts
{
    public class GetAllCarPartsQueryRequest :  IRequest<IList<GetAllCarPartsQueryResponse>>
    {
    }
}
