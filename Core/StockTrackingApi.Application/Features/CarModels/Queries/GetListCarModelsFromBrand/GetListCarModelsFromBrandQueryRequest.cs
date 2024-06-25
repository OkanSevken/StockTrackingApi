using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarModels.Queries.GetListCarModelsFromBrand
{
    public class GetListCarModelsFromBrandQueryRequest : IRequest<IList<GetListCarModelsFromBrandQueryResponse>>
    {
        public int Id { get; set; }
    }
}
