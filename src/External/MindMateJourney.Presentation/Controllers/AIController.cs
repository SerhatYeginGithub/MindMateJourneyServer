using MediatR;
using Microsoft.AspNetCore.Mvc;
using MindMateJourney.Application.Features.GeminiFeatures.Commands.GeminiGenerateContentCommand;
using MindMateJourney.Presentation.Abstractions;

namespace MindMateJourney.Presentation.Controllers;

public sealed class AIController : ApiController
{
    private readonly IMediator _mediator;

    public AIController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GeminiGenerate(GeminiGenerateContentCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
