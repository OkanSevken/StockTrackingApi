using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartBrandModels.Command.CreatePartBrandModel
{
    public class CreatePartBrandModelCommandRequest : IRequest<Unit>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
    }
}
