using MediatR;
using Microsoft.AspNetCore.Mvc;
using MindMateJourney.Application.Features.ContentFeatures.Commands.CreateContentCommand;
using MindMateJourney.Application.Features.ContentFeatures.Commands.DeleteContentCommand;
using MindMateJourney.Application.Features.ContentFeatures.Commands.UpdateContentCommand;
using MindMateJourney.Presentation.Abstractions;

namespace MindMateJourney.Presentation.Controllers;

public sealed class ContentsController : ApiController
{
    private readonly IMediator _mediator;
    public ContentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateContent(CreateContentCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateContent(UpdateContentCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteContent(string id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new DeleteContentCommand(id), cancellationToken);
        return Ok(response);
    }
}
