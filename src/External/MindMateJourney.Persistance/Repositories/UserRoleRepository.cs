using MindMateJourney.Application.Repositories;
using MindMateJourney.Domain.Entities;
using MindMateJourney.Persistance.Abstractions;
using MindMateJourney.Persistance.Context;

namespace MindMateJourney.Persistance.Repositories;

public sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context) : base(context)
    {
    }
}
