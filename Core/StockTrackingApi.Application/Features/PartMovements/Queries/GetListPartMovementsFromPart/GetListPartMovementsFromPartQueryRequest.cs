using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Queries.GetListPartMovementsFromPart
{
    public class GetListPartMovementsFromPartQueryRequest : IRequest<IList<GetListPartMovementsFromPartQueryResponse>>
    {
        public int Id { get; set; }
    }
}
