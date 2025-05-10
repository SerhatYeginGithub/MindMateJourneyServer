using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.UserRoleFeatures.Commands.CreateUserRoleCommand;

public sealed record CreateUserRoleCommand(
    string RoleId,
    string UserId) : IRequest<MessageResponse>;
