using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;
namespace MindMateJourney.Application.Features.CategoryFeatures.Queries.GetAllCategoriesQuery;

public sealed class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, IList<GetAllCategoriesDto>>
{
    private readonly ICategoryService _categoryService;
    public GetAllCategoriesQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async Task<IList<GetAllCategoriesDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
       return await _categoryService.GetAllAsync(request, cancellationToken);
    }
}
