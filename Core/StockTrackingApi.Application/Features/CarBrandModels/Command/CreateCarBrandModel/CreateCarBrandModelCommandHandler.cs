using MediatR;
using StockTrackingApi.Application.Features.PartBrandModels.Command.CreatePartBrandModel;
using StockTrackingApi.Application.Features.Parts.Command.CreatePart;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarBrandModels.Command.CreateCarBrandModel
{
    public class CreateCarBrandModelCommandHandler : IRequestHandler<CreateCarBrandModelCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateCarBrandModelCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateCarBrandModelCommandRequest request, CancellationToken cancellationToken)
        {
            CarBrandModel carBrandModel = new
              (
                  request.Brand,
                  request.Model,
                  request.Year
              );
            carBrandModel.CreatedDate = DateTime.Now;
            carBrandModel.CreaterUserId = 1;
            carBrandModel.IsActive = true;
            carBrandModel.IsDeleted = false;

            await unitOfWork.GetWriteRepository<CarBrandModel>().AddAsync(carBrandModel);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
