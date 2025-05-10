using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.AuthFeatures.Commands.LoginCommand;

public sealed record LoginCommand(
 string UserNameOrEmail,
 string Password) : IRequest<LoginCommandResponse>;