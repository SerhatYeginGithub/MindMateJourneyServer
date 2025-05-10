using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MindMateJourney.Application.Abstractions;
using MindMateJourney.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;
    private readonly UserManager<AppUser> _userManager;
    public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<AppUser> userManager)
    {
        _jwtOptions = jwtOptions.Value;
        _userManager = userManager;
    }

    public async Task<LoginCommandResponse> CreateTokenAsync(AppUser user)
    {
        var claims = new Claim[]
        {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim("NameLastName", user.NameLastName)
        };

        DateTime expires = DateTime.Now.AddMinutes(1);
        DateTime refreshTokenExpire = DateTime.Now.AddDays(7);
        JwtSecurityToken jwtSecurityToken = new(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256)
            );

        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = refreshTokenExpire;
        await _userManager.UpdateAsync(user);

        LoginCommandResponse response = new(
            token,
            refreshToken,
            user.RefreshTokenExpires,
           user.Id);

        return response;
    }
}

