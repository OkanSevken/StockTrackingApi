using MediatR;
using StockTrackingApi.Application.Interfaces.AutoMapper;
using StockTrackingApi.Application.Interfaces.UnitOfWorks;
using StockTrackingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrackingApi.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = new
            (
                request.CategoryName
            );
            category.CreatedDate = DateTime.Now;
            category.CreaterUserId = 1;
            category.IsActive = true;
            category.IsDeleted = false;

            await unitOfWork.GetWriteRepository<Category>().AddAsync(category);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
