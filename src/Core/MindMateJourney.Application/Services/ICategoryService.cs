using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.CreateCategoryCommand;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.DeleteCategoryCommand;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.UpdateCategoryCommand;
using MindMateJourney.Application.Features.CategoryFeatures.Queries.GetAllCategoriesQuery;
using MindMateJourney.Application.Features.CategoryFeatures.Queries.GetCategoryById;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Application.Services;

public interface ICategoryService
{
    public Task CreateAsync(CreateCategoryCommand request, CancellationToken cancellationToken);
    public Task UpdateAsync(UpdateCategoryCommand request, CancellationToken cancellationToken);
    public Task<IList<GetAllCategoriesDto>> GetAllAsync(GetAllCategoriesQuery request, CancellationToken cancellationToken);
    public Task<GetCategoryByIdDto> GetByIdAsync( GetCategoryByIdQuery request, CancellationToken cancellationToken);
    public Task DeleteAsync(DeleteCategoryCommand request, CancellationToken cancellationToken);
}
