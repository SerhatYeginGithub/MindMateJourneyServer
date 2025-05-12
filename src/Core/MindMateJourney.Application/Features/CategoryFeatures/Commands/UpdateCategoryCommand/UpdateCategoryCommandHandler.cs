using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.CategoryFeatures.Commands.UpdateCategoryCommand;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, MessageResponse>
{
    private readonly ICategoryService _categoryService;

    public UpdateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<MessageResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoryService.UpdateAsync(request, cancellationToken);
        return new("Category Updated Successfully.", true);
    }
}
