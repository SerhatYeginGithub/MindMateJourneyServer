using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshTokenCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.LoginCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.LogoutCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.RegisterCommand;
using MindMateJourney.Application.Features.AuthFeatures.Commands.VerifyCodeCommand;
using MindMateJourney.Domain.Entities;
using MindMateJourney.Presentation.Abstractions;

namespace MindMateJourney.Presentation.Controllers;

public sealed class AuthController : ApiController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[Action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("[Action]")]
    [AllowAnonymous]
    public async Task<IActionResult> VerifyCode([FromBody] VerifyCodeCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateTokenByRefreshToken(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Logout(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new LogoutCommand(), cancellationToken);
        return Ok(result);
    }
}
