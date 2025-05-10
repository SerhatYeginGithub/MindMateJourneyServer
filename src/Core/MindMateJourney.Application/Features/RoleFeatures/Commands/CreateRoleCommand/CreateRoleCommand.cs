using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.RoleFeatures.Commands.CreateRoleCommand;

public sealed record CreateRoleCommand(string Name) : IRequest<MessageResponse>;
