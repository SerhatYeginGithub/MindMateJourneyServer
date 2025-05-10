using MindMateJourney.Application.DTOS;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Application.Abstractions;

public interface IJwtProvider
{
    Task<LoginCommandResponse> CreateTokenAsync(AppUser user);
}