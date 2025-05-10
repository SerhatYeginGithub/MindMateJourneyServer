using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.AuthFeatures.Commands.LogoutCommand;

public sealed class LogoutCommandHandler(IAuthService authService) : IRequestHandler<LogoutCommand, MessageResponse>
{
    public async Task<MessageResponse> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await authService.LogoutAsync(request, cancellationToken);
        return new("User logout successfully.");
    }
}
