using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarBrands.Command.CreateCarBrand
{
    public class CreateCarBrandCommandRequest : IRequest<Unit>
    {
        public string BrandName { get; set; }
    }
}
