using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartBrandModels.Command.DeletePartBrandModel
{
    public class DeletePartBrandModelCommandHandler : IRequestHandler<DeletePartBrandModelCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DeletePartBrandModelCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeletePartBrandModelCommandRequest request, CancellationToken cancellationToken)
        {
            var partBrandModels = await unitOfWork.GetReadRepository<PartBrandModel>().GetAsync(x => x.Id == request.Id && x.IsDeleted == false);

            partBrandModels.IsDeleted = true;
            partBrandModels.LastModifyDate = DateTime.Now;

            partBrandModels.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<PartBrandModel>().UpdateAsync(partBrandModels);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
