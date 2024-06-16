using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarBrandModels.Command.CreateCarBrandModel
{
    public class CreateCarBrandModelCommandRequest : IRequest<Unit>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
