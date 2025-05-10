using MediatR;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshTokenCommand;

public sealed class CreateNewTokenByRefreshTokenCommandHandler : IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
{
    private readonly IAuthService _authService;

    public CreateNewTokenByRefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        LoginCommandResponse response = await _authService.CreateTokenByRefreshTokenAsync(request, cancellationToken);
        return response;
    }
}
