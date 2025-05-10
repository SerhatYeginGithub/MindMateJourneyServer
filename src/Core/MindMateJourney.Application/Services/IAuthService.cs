using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshTokenCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.LoginCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.LogoutCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.RegisterCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.VerifyCodeCommand;

namespace MindMateJourney.Application.Services;

public interface IAuthService
{
    public Task RegisterAsync(RegisterCommand request, CancellationToken cancellationToken);
    Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);
    Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken);
    public Task VerifyCodeAsync(VerifyCodeCommand request, CancellationToken cancellationToken);

    public Task LogoutAsync(LogoutCommand request, CancellationToken cancellationToken);
}
