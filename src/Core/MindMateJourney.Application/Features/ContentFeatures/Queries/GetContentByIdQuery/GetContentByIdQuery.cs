using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.ContentFeatures.Queries.GetContentByIdQuery;

public sealed record GetContentByIdQuery(string Id) : IRequest<ContentDto>;
