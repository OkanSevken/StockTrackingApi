using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartBrandModels.Command.UpdatePartBrandModel
{
    public class UpdatePartBrandModelCommandHandler : IRequestHandler<UpdatePartBrandModelCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UpdatePartBrandModelCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdatePartBrandModelCommandRequest request, CancellationToken cancellationToken)
        {
            var partBrandModels = await unitOfWork.GetReadRepository<PartBrandModel>().GetAsync(x => x.Id == request.Id && x.IsActive == true && x.IsDeleted == false);

            partBrandModels.Brand = request.Brand;
            partBrandModels.Model = request.Model;
            partBrandModels.Category = request.Category;

            partBrandModels.LastModifyDate = DateTime.Now;

            // var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            partBrandModels.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<PartBrandModel>().UpdateAsync(partBrandModels);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
