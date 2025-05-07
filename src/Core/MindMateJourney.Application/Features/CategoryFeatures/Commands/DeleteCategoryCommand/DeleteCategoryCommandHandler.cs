using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.CategoryFeatures.Commands.DeleteCategoryCommand
{
    public sealed class DeleteCategoryCommandHandlerI(ICategoryService categoryService) : IRequestHandler<DeleteCategoryCommand, MessageResponse>
    {
        public async Task<MessageResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await categoryService.DeleteAsync(request, cancellationToken);
            return new("Category deleted successfully.");
        }
    }
}
