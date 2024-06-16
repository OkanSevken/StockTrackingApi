using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarBrandModels.Command.DeleteCarBrandModel
{
    public class DeleteCarBrandModelCommandRequest: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
