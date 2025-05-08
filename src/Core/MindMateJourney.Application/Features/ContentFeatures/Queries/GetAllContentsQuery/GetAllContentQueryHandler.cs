using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.ContentFeatures.Queries.GetAllContentsQuery;

public sealed class GetAllContentQueryHandler : IRequestHandler<GetAllContentQuery, List<ContentDto>>
{
    private readonly IContentService _contentService;
    public GetAllContentQueryHandler(IContentService contentService)
    {
        _contentService = contentService;
    }

    public async Task<List<ContentDto>> Handle(GetAllContentQuery request, CancellationToken cancellationToken) => await _contentService.GetAllAsync(request, cancellationToken);
}
