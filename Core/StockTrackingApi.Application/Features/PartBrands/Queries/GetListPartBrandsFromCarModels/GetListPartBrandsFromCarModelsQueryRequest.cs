using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartBrands.Queries.GetListPartBrandsFromCarModels
{
    public class GetListPartBrandsFromCarModelsQueryRequest : IRequest<IList<GetListPartBrandsFromCarModelsQueryResponse>>
    {
        public int Id { get; set; }
    }
}
