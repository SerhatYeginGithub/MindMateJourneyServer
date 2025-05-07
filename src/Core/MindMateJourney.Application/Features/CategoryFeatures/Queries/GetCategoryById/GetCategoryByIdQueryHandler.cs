using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.CategoryFeatures.Queries.GetCategoryById;

public sealed class GetCategoryByIdQueryHandler(ICategoryService categoryService) : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdDto>
{
    public async Task<GetCategoryByIdDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken) => await categoryService.GetByIdAsync(request, cancellationToken);
}
