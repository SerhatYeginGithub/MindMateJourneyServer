using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshTokenCommand;

public sealed record CreateNewTokenByRefreshTokenCommand(
    string UserId,
    string RefreshToken) : IRequest<LoginCommandResponse>;
