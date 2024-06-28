using MediatR;
using StockTrackingApi.Application.Features.PartModels.Queries.GetListPartModelsFromBrand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartModels.Queries.GetListPartModelsFromModel
{
    public class GetListPartModelsFromModelQueryRequest : IRequest<IList<GetListPartModelsFromModelQueryResponse>>
    {
        public int Id { get; set; }
    }
}
