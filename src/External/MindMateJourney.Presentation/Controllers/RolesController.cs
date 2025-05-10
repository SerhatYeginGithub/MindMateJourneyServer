using MediatR;
using Microsoft.AspNetCore.Mvc;
using MindMateJourney.Application.DTOS;
using MindMateJourney.Application.Features.RoleFeatures.Commands.CreateRoleCommand;
using MindMateJourney.Infrastructure.Authorization;
using MindMateJourney.Presentation.Abstractions;

namespace MindMateJourney.Presentation.Controllers;


public sealed class RolesController : ApiController
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    [RoleFilter("Admin")]
    public async Task<IActionResult> Create(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        MessageResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
