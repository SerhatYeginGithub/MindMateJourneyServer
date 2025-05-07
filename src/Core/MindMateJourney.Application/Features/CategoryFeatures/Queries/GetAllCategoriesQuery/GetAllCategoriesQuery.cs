using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.CategoryFeatures.Queries.GetAllCategoriesQuery
{
    public sealed record GetAllCategoriesQuery() : IRequest<IList<GetAllCategoriesDto>>;

}
