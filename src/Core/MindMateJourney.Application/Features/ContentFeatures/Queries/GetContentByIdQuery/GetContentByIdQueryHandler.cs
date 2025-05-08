using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.ContentFeatures.Queries.GetContentByIdQuery;

public sealed class GetContentByIdQueryHandler : IRequestHandler<GetContentByIdQuery, ContentDto>
{
    private readonly IContentService _contentService;

    public GetContentByIdQueryHandler(IContentService contentService)
    {
        _contentService = contentService;
    }

    public async Task<ContentDto> Handle(GetContentByIdQuery request, CancellationToken cancellationToken) => await _contentService.GetByIdAsync(request, cancellationToken);
}

