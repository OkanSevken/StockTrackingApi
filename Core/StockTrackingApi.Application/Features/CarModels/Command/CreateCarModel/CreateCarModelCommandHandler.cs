using MediatR;
using StockTrackingApi.Application.Features.CarBrands.Command.CreateCarBrand;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarModels.Command.CreateCarModel
{
    public class CreateCarModelCommandHandler : IRequestHandler<CreateCarModelCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateCarModelCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateCarModelCommandRequest request, CancellationToken cancellationToken)
        {
            CarModel carModel = new
            (
                request.ModelName,
                request.Year,
                request.CarBrandId
            );
            carModel.CreatedDate = DateTime.Now;
            carModel.CreaterUserId = 1;
            carModel.IsActive = true;
            carModel.IsDeleted = false;

            await unitOfWork.GetWriteRepository<CarModel>().AddAsync(carModel);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
