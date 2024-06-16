using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.WarehouseParts.Command.DeleteWarehousePart
{
    public class DeleteWarehousePartCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
