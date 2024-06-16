using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartBrandModels.Command.CreatePartBrandModel
{
    public class CreatePartBrandModelCommandHandler : IRequestHandler<CreatePartBrandModelCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreatePartBrandModelCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreatePartBrandModelCommandRequest request, CancellationToken cancellationToken)
        {
            PartBrandModel partBrandModel = new
              (
                  request.Brand,
                  request.Model,
                  request.Category
              );
            partBrandModel.CreatedDate = DateTime.Now;
            partBrandModel.CreaterUserId = 1;
            partBrandModel.IsActive = true;
            partBrandModel.IsDeleted = false;

            await unitOfWork.GetWriteRepository<PartBrandModel>().AddAsync(partBrandModel);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
