namespace MindMateJourney.Application.DTOS;

public sealed record LoginCommandResponse(
 string Token,
 string RefreshToken,
 DateTime? RefreshTokenExpires,
 string UserId);
