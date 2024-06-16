using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarBrandModels.Command.DeleteCarBrandModel
{
    public class DeletePartBrandModelCommandHandler : IRequestHandler<DeleteCarBrandModelCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DeletePartBrandModelCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteCarBrandModelCommandRequest request, CancellationToken cancellationToken)
        {
            var carBrandModels = await unitOfWork.GetReadRepository<CarBrandModel>().GetAsync(x => x.Id == request.Id && x.IsDeleted == false);

            carBrandModels.IsDeleted = true;
            carBrandModels.LastModifyDate = DateTime.Now;

            carBrandModels.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<CarBrandModel>().UpdateAsync(carBrandModels);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
