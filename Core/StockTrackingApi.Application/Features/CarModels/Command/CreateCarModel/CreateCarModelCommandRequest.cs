using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarModels.Command.CreateCarModel
{
    public class CreateCarModelCommandRequest : IRequest<Unit>
    {
        public string ModelName { get; set; }
        public int Year { get; set; }
        public int CarBrandId { get; set; }
    }
}
