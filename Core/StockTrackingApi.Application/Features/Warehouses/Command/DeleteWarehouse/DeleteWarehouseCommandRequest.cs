using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Warehouses.Command.DeleteWarehouse
{
    public class DeleteWarehouseCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
