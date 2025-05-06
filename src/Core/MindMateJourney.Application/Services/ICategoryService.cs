using MindMateJourney.Application.Features.CategoryFeatures.Commands.CreateCategoryCommand;

namespace MindMateJourney.Application.Services;

public interface ICategoryService
{
    Task CreateAsync(CreateCategoryCommand request, CancellationToken cancellationToken);
}
