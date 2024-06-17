using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarParts.Command.UpdateCarParts
{
    public class UpdateCarPartsCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public int CarModelId { get; set; }
        public int PartModelId { get; set; }
    }
}
