using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.CategoryFeatures.Commands.CreateCategoryCommand
{
    public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, MessageResponse>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<MessageResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryService.CreateAsync(request, cancellationToken);
            return new("Category created successfully");
        }
    }
}
