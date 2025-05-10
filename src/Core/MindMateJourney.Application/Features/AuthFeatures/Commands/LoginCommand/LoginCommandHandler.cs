using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.AuthFeatures.Commands.LoginCommand;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _authService.LoginAsync(request, cancellationToken);

        return response;
    }
}
