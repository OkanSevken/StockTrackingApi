using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.WarehouseParts.Command.CreateWarehousePart
{
    public class CreateWarehousePartCommandRequest : IRequest<Unit>
    {
        public int WarehouseId { get; set; }
        public int PartId { get; set; }
        public int StockQuantity { get; set; }
    }
}
