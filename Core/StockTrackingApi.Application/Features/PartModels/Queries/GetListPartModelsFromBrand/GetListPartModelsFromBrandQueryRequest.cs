using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartModels.Queries.GetListPartModelsFromBrand
{
    public class GetListPartModelsFromBrandQueryRequest : IRequest<IList<GetListPartModelsFromBrandQueryResponse>>
    {
        public int Id { get; set; }
    }
}
