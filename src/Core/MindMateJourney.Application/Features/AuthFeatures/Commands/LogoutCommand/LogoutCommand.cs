using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.AuthFeatures.Commands.LogoutCommand;

public sealed record LogoutCommand() : IRequest<MessageResponse>;
