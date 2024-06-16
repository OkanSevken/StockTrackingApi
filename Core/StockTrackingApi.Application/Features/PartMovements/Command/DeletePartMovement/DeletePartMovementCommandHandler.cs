using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Command.DeletePartMovement
{
    public class DeletePartMovementCommandHandler : IRequestHandler<DeletePartMovementCommandRequest,Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DeletePartMovementCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePartMovementCommandRequest request, CancellationToken cancellationToken)
        {
            var partMovements = await unitOfWork.GetReadRepository<PartMovement>().GetAsync(x => x.Id == request.Id && x.IsDeleted == false);

            partMovements.IsDeleted = true;
            partMovements.LastModifyDate = DateTime.Now;

            // var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            partMovements.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<PartMovement>().UpdateAsync(partMovements);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
