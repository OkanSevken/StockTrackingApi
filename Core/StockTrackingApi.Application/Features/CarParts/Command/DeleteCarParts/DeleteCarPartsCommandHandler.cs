using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarParts.Command.DeleteCarParts
{
    public class DeleteCarPartsCommandHandler : IRequestHandler<DeleteCarPartsCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DeleteCarPartsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteCarPartsCommandRequest request, CancellationToken cancellationToken)
        {
            var carParts = await unitOfWork.GetReadRepository<CarPart>().GetAsync(x => x.Id == request.Id && x.IsDeleted == false);

            carParts.IsDeleted = true;
            carParts.LastModifyDate = DateTime.Now;

            carParts.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<CarPart>().UpdateAsync(carParts);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
