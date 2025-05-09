using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.AuthFeatures.Commands.RegisterCommand;

public sealed record RegisterCommand(string Email, string Password, string NameLastName, string UserName) : IRequest<MessageResponse>;