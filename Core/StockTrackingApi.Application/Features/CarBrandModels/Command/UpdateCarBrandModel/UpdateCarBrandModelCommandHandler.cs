using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarBrandModels.Command.UpdateCarBrandModel
{
    public class UpdateCarBrandModelCommandHandler : IRequestHandler<UpdateCarBrandModelCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateCarBrandModelCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateCarBrandModelCommandRequest request, CancellationToken cancellationToken)
        {
            var carBrandModels = await unitOfWork.GetReadRepository<CarBrandModel>().GetAsync(x => x.Id == request.Id && x.IsActive == true && x.IsDeleted == false);

            carBrandModels.Brand = request.Brand;
            carBrandModels.Model = request.Model;
            carBrandModels.Year = request.Year;

            carBrandModels.LastModifyDate = DateTime.Now;

            // var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            carBrandModels.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<CarBrandModel>().UpdateAsync(carBrandModels);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
