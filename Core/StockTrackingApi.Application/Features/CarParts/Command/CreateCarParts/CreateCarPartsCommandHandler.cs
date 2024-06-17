using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.CarParts.Command.CreateCarParts
{
    public class CreateCarPartsCommandHandler : IRequestHandler<CreateCarPartsCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateCarPartsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateCarPartsCommandRequest request, CancellationToken cancellationToken)
        {          
            CarPart carPart = new
                (
                    request.CarModelId,
                    request.PartModelId
                );

            carPart.CreatedDate = DateTime.Now;
            carPart.CreaterUserId = 1;
            carPart.IsActive = true;
            carPart.IsDeleted = false;


            await unitOfWork.GetWriteRepository<CarPart>().AddAsync(carPart);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
