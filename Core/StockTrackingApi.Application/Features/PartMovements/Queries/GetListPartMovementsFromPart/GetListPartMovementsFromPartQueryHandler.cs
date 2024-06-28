using MediatR;
using StockTrackingApi.Application.Features.Parts.Queries.GetListPartsFromBrand;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.PartMovements.Queries.GetListPartMovementsFromPart
{
    public class GetListPartMovementsFromPartQueryHandler : IRequestHandler<GetListPartMovementsFromPartQueryRequest, IList<GetListPartMovementsFromPartQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetListPartMovementsFromPartQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IList<GetListPartMovementsFromPartQueryResponse>> Handle(GetListPartMovementsFromPartQueryRequest request, CancellationToken cancellationToken)
        {
            var parts = await unitOfWork.GetReadRepository<Part>().GetAllAsync(x => x.IsActive && !x.IsDeleted);
            var partMovements = await unitOfWork.GetReadRepository<PartMovement>().GetAllAsync(x => x.PartId == request.Id && x.IsActive == true && !x.IsDeleted);
            var warehouses = await unitOfWork.GetReadRepository<Warehouse>().GetAllAsync(x => x.IsActive == true && x.IsDeleted == false);

            List<GetListPartMovementsFromPartQueryResponse> map = new List<GetListPartMovementsFromPartQueryResponse>();

            foreach (var partMovement in partMovements)
            {
                var part = parts.FirstOrDefault(x => x.Id == partMovement.PartId)?.Name;
                var warehouse=warehouses.FirstOrDefault(x => x.Id==partMovement.WarehouseId)?.Name;

                map.Add(new GetListPartMovementsFromPartQueryResponse
                {
                    Id = partMovement.Id,                 
                    PartName=part,
                    WarehouseName = warehouse,
                    Amount = partMovement.Amount,
                    Price = partMovement.Price,
                    Invoice= partMovement.Invoice,
                    Date=partMovement.Date,
                    MovementType=partMovement.MovementType,
                    Description=partMovement.Description,
                });
            }
            return map;
        }
    }
}
