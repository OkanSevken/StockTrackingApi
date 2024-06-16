using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.WarehouseParts.Command.UpdateWarehousePart
{
    public class UpdateWarehousePartCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int PartId { get; set; }
        public int StockQuantity { get; set; }
    }
}
