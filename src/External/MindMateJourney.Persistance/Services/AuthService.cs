using System.Runtime.CompilerServices;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MindMateJourney.Application.Features.AuthFeatures.Commands.RegisterCommand;
using MindMateJourney.Application.Services;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Persistance.Services;

public sealed class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    public AuthService(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    
    public async Task RegisterAsync(RegisterCommand request, CancellationToken cancellationToken)
    {
        var isEmailExist = await IsEmailExistAsync(request.Email);

        if (isEmailExist)
            throw new Exception("This email is already taken.");

       AppUser user = _mapper.Map<AppUser>(request);
       IdentityResult result = await  _userManager.CreateAsync(user, request.Password);
        
        if(!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
    }

    private async Task<bool> IsEmailExistAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user != null;
    }
}
