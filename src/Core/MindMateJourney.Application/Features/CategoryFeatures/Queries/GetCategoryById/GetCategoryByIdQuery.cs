using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.CategoryFeatures.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery(string Id) : IRequest<GetCategoryByIdDto>;

