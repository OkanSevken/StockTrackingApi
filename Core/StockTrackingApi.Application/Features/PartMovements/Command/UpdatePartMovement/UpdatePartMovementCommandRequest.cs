using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Command.UpdatePartMovement
{
    public class UpdatePartMovementCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public int WarehouseId { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public bool Invoice { get; set; }
        public string MovementType { get; set; }
        public string Description { get; set; }
    }
}
