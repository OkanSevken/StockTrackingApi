using MediatR;
using StockTrackingApi.Application.Features.Parts.Queries.GetAllListParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Warehouses.Queries.GetAllListWarehouse
{
    public class GetAllWarehouseQueryRequest : IRequest<IList<GetAllWarehouseQueryResponse>>
    {
    }
}
