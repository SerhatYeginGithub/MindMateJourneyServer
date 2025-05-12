using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.AuthFeatures.Commands.VerifyCodeCommand;

public sealed class VerifyCodeCommandHandler : IRequestHandler<VerifyCodeCommand, MessageResponse>
{
    private readonly IAuthService _authService;

    public VerifyCodeCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<MessageResponse> Handle(VerifyCodeCommand request, CancellationToken cancellationToken)
    {
        await _authService.VerifyCodeAsync(request, cancellationToken);
        return new("User registered successfully.", true);
    }
}
