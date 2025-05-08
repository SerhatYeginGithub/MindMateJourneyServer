using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.ContentFeatures.Queries.GetAllContentsQuery;

public sealed record GetAllContentQuery(int PageNumber = 1, int PageSize = 10) : IRequest<List<ContentDto>>;

