using MediatR;
using Microsoft.AspNetCore.Mvc;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.CreateCategoryCommand;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.DeleteCategoryCommand;
using MindMateJourney.Application.Features.CategoryFeatures.Commands.UpdateCategoryCommand;
using MindMateJourney.Application.Features.CategoryFeatures.Queries.GetAllCategoriesQuery;
using MindMateJourney.Application.Features.CategoryFeatures.Queries.GetCategoryById;
using MindMateJourney.Presentation.Abstractions;

namespace MindMateJourney.Presentation.Controllers;

public sealed class CategoriesController : ApiController
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllCategories(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllCategoriesQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("GetCategoryById/{id}")]
    public async Task<IActionResult> GetCategoryById(string id, CancellationToken cancellationToken)
    {
        GetCategoryByIdQuery request = new(id);
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteCategory(string id, CancellationToken cancellationToken)
    {
        DeleteCategoryCommand request = new(id);
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

}
