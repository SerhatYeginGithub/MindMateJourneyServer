using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.ContentFeatures.Commands.UpdateContentCommand;

public sealed class UpdateContentCommandHandler : IRequestHandler<UpdateContentCommand, MessageResponse>
{
    private readonly IContentService _contentService;

    public UpdateContentCommandHandler(IContentService contentService)
    {
        _contentService = contentService;
    }

    public async Task<MessageResponse> Handle(UpdateContentCommand request, CancellationToken cancellationToken)
    {
        await _contentService.UpdateAsync(request, cancellationToken);
        return new MessageResponse("Content Updated Successfully", true);
    }
}
