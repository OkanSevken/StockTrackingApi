using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarParts.Command.CreateCarParts
{
    public class CreateCarPartsCommandRequest : IRequest<Unit>
    {
        public int CarModelId { get; set; }
        public int PartModelId { get; set; }
    }
}
