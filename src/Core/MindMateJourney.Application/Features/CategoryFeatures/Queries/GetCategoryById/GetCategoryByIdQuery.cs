using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.CategoryFeatures.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery(string Id, int PageNumber = 1, int PageSize = 10) : IRequest<GetCategoryByIdDto>;

