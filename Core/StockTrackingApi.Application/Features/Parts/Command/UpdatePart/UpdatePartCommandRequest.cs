using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Command.UpdatePart
{
    public class UpdatePartCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PartCode { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; }
        public float Vat { get; set; }
        public int Stock { get; set; }
    }
}
