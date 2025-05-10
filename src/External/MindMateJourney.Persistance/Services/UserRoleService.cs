using GenericRepository;
using MindMateJourney.Application.Features.UserRoleFeatures.Commands.CreateUserRoleCommand;
using MindMateJourney.Application.Repositories;
using MindMateJourney.Application.Services;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Services;

public sealed class UserRoleService : IUserRoleService
{
    private readonly IUserRoleRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public UserRoleService(IUserRoleRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task CreateAsync(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        UserRole userRole = new()
        {
            RoleId = request.RoleId,
            UserId = request.UserId
        };

        await _repository.AddAsync(userRole, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
