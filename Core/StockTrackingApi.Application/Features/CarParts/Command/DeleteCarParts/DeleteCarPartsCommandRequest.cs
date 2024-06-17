using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarParts.Command.DeleteCarParts
{
    public class DeleteCarPartsCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
