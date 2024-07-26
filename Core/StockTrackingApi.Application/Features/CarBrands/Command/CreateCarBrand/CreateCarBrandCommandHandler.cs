using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarBrands.Command.CreateCarBrand
{
    public class CreateCarBrandCommandHandler : IRequestHandler<CreateCarBrandCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateCarBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateCarBrandCommandRequest request, CancellationToken cancellationToken)
        {
            CarBrand carBrand = new
            (
                request.BrandName
            );
            carBrand.CreatedDate = DateTime.Now;
            carBrand.CreaterUserId = 1;
            carBrand.IsActive = true;
            carBrand.IsDeleted = false;

            await unitOfWork.GetWriteRepository<CarBrand>().AddAsync(carBrand);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
