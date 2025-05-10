using MediatR;
using Microsoft.AspNetCore.Mvc;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Features.UserRoleFeatures.Commands.CreateUserRoleCommand;
using MindMateJourney.Infrastructure.Authorization;
using MindMateJourney.Presentation.Abstractions;

namespace MindMateJourney.Presentation.Controllers;

public sealed class UserRolesController : ApiController
{
    private readonly IMediator _mediator;

    public UserRolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    [RoleFilter("Admin")]
    public async Task<IActionResult> Create(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
