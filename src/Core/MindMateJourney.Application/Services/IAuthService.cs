using MindMateJourney.Application.Features.AuthFeatures.Commands.RegisterCommand;

namespace MindMateJourney.Application.Services;

public interface IAuthService
{
    public Task RegisterAsync(RegisterCommand request, CancellationToken cancellationToken);
}
