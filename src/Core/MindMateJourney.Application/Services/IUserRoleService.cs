using MindMateJourney.Application.Features.UserRoleFeatures.Commands.CreateUserRoleCommand;

namespace MindMateJourney.Application.Services;

public interface IUserRoleService
{
    public Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken);

}
