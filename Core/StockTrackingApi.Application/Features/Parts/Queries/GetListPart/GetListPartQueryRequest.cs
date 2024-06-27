using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Queries.GetListPart
{
    public class GetListPartQueryRequest : IRequest<IList<GetListPartQueryResponse>>
    {
        public GetListPartQueryRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
