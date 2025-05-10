using Microsoft.AspNetCore.Identity;
using MindMateJourney.Application.Features.RoleFeatures.Commands.CreateRoleCommand;
using MindMateJourney.Application.Services;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Services;

public sealed class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;

    public RoleService(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task CreateAsync(CreateRoleCommand request)
    {
        Role role = new()
        {
            Name = request.Name
        };

        await _roleManager.CreateAsync(role);
    }
}
