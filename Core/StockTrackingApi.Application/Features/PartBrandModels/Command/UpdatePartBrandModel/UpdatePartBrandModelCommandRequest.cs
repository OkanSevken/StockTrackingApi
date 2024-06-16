using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartBrandModels.Command.UpdatePartBrandModel
{
    public class UpdatePartBrandModelCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
    }
}
