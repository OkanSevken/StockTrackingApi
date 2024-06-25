using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Command.CreatePart
{
    public class CreatePartCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float PurchasePrice { get; set; }
        //public float SalePrice { get; set; } 
        public float Vat { get; set; }
        // public int Stock { get; set; }
        public int CategoryId { get; set; }
        public int PartModelId { get; set; }
    }
}
