using System.Runtime.CompilerServices;
using System.Security.Claims;
using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MindMateJourney.Application.Abstractions;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshTokenCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.LoginCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.LogoutCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.RegisterCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.VerifyCodeCommand;
using MindMateJourney.Application.Services;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Services;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IMailService _mailService;
    private readonly IMemoryCache _cache;
    private readonly IJwtProvider _jwtProvider;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AuthService(UserManager<AppUser> userManager, IMapper mapper, IMemoryCache cache, IMailService mailService, IJwtProvider jwtProvider, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _mapper = mapper;
        _cache = cache;
        _mailService = mailService;
        _jwtProvider = jwtProvider;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task RegisterAsync(RegisterCommand request, CancellationToken cancellationToken)
    {
        var isEmailExist = await IsEmailExistAsync(request.Email);
        var isUserNameExist = await IsUserNameExistAsync(request.UserName);
        if (isEmailExist)
            throw new Exception("This email is already taken.");

        if (isUserNameExist)
            throw new Exception("This username is already taken.");

        var code = new Random().Next(100000, 999999).ToString();

        await _mailService.SendEmailAsync(request.Email, request.NameLastName, code);

        _cache.Set(request.Email, (request, code), TimeSpan.FromMinutes(2));

    }

    public async Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken)
    {
        AppUser? user =
            await _userManager.Users
            .Where(
                p => p.UserName == request.UserNameOrEmail
                  || p.Email == request.UserNameOrEmail)
            .FirstOrDefaultAsync(cancellationToken);

        if (user == null) throw new Exception("Kullanıcı bulunamadı!");

        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        if (result)
        {
            LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
            return response;
        }

        throw new Exception("Kullanıcı Adı veya şifre hatalı.");

    }

    private async Task<bool> IsEmailExistAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user != null;
    }
    private async Task<bool> IsUserNameExistAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        return user != null;
    }

    public async Task VerifyCodeAsync(VerifyCodeCommand request, CancellationToken cancellationToken)
    {
        if (_cache.TryGetValue<(RegisterCommand, string)>(request.Email, out var cachedData))
        {
            var (registerRequest, storedCode) = cachedData;

            if (storedCode == request.Code)
            {
                _cache.Remove(registerRequest.Email);
                
                AppUser user = _mapper.Map<AppUser>(registerRequest);

                IdentityResult result = await _userManager.CreateAsync(user, registerRequest.Password);

                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

            }
            else
            {
                throw new Exception("Doğrulama kodu hatalı.");
            }
        }
        else
        {
            throw new Exception("Doğrulama kodu süresi dolmuş veya geçersiz.");
        }
    }

    public async Task<LoginCommandResponse> CreateTokenByRefreshTokenAsync(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null) throw new Exception("Kullanıcı bulunamadı!");

        if (user.RefreshToken != request.RefreshToken)
            throw new Exception("Refresh Token geçerli değil!");

        if (user.RefreshTokenExpires < DateTime.Now)
            throw new Exception("Refresh Tokenun süresi dolmuş!");

        LoginCommandResponse response = await _jwtProvider.CreateTokenAsync(user);
        return response;
    }

    public async Task LogoutAsync(LogoutCommand request, CancellationToken cancellationToken)
    {
        var userClaims = _httpContextAccessor.HttpContext?.User;
        var userId = userClaims?.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
            throw new Exception("User not found");

        AppUser? appUser = await GetUserByIdAsync(userId);
        if (appUser == null)
            throw new Exception("User not found");

        appUser.RefreshToken = null;
        appUser.RefreshTokenExpires = null;
        await _userManager.UpdateAsync(appUser);
    }

    private async Task<AppUser?> GetUserByIdAsync(string Id)
    {
        var user = await _userManager.FindByIdAsync(Id);
        return user;
    }
}

