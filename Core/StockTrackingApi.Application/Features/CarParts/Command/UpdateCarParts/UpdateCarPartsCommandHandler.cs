using MediatR;
using StockTrackingApi.Application.Features.PartBrandModels.Command.UpdatePartBrandModel;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarParts.Command.UpdateCarParts
{
    public class UpdateCarPartsCommandHandler : IRequestHandler<UpdateCarPartsCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdateCarPartsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateCarPartsCommandRequest request, CancellationToken cancellationToken)
        {
            var carParts = await unitOfWork.GetReadRepository<CarPart>().GetAsync(x => x.Id == request.Id && x.IsActive == true && x.IsDeleted == false);

            carParts.CarModelId = request.CarModelId;
            carParts.PartModelId = request.PartModelId;


            carParts.LastModifyDate = DateTime.Now;

            // var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            carParts.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<CarPart>().UpdateAsync(carParts);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
