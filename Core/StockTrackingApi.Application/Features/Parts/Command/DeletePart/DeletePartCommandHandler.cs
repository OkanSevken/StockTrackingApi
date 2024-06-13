using MediatR;
using Microsoft.AspNetCore.Identity;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Parts.Command.DeletePart
{
    public class DeletePartCommandHandler : IRequestHandler<DeletePartCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DeletePartCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePartCommandRequest request, CancellationToken cancellationToken)
        {
            var parts = await unitOfWork.GetReadRepository<Part>().GetAsync(x => x.Id == request.Id && x.IsDeleted == false);

            parts.IsDeleted = true;
            parts.LastModifyDate = DateTime.Now;

           // var user = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            parts.LastUserId = request.Id;

            await unitOfWork.GetWriteRepository<Part>().UpdateAsync(parts);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
