using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Command.DeletePartMovement
{
    public class DeletePartMovementCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
