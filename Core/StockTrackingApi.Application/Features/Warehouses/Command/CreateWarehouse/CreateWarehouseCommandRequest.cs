using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Warehouses.Command.CreateWarehouse
{
    public class CreateWarehouseCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
