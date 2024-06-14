using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Command.CreatePartMovement
{
    public class CreatePartMovementCommandRequest : IRequest<Unit>
    {
        public int PartId { get; set; }
        public int WarehouseId { get; set; }
        public int Amount { get; set; }
        public string MovementType { get; set; } 
        public string Description { get; set; }
    }
}
