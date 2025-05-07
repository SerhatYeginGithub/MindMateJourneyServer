using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.ContentFeatures.Commands.DeleteContentCommand;

public sealed class DeleteContentCommandHandler : IRequestHandler<DeleteContentCommand, MessageResponse>
{
    private readonly IContentService _contentService;

    public DeleteContentCommandHandler(IContentService contentService)
    {
        _contentService = contentService;
    }

    public async Task<MessageResponse> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
    {
        await _contentService.DeleteAsync(request, cancellationToken);
        return new MessageResponse("Content Deleted Successfully");
    }
}
