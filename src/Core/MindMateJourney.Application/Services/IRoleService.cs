using MindMateJourney.Application.Features.RoleFeatures.Commands.CreateRoleCommand;

namespace MindMateJourney.Application.Services;

public interface IRoleService
{
    public Task CreateAsync(CreateRoleCommand request);
}
