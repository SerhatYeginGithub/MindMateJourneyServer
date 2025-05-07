using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.ContentFeatures.Commands.CreateContentCommand;

public sealed class CreateContentCommandHandler(IContentService contentService) : IRequestHandler<CreateContentCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(CreateContentCommand request, CancellationToken cancellationToken)
    {
        await contentService.CreateAsync(request, cancellationToken);
        return new("Content Created Successfully");
    }
}
