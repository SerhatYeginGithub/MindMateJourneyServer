using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.CategoryFeatures.Commands.UpdateCategoryCommand;

public sealed record UpdateCategoryCommand
    (string Id, string Name) : IRequest<MessageResponse>;

