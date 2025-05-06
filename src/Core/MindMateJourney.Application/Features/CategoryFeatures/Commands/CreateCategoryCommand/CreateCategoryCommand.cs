using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.CategoryFeatures.Commands.CreateCategoryCommand;

public sealed record CreateCategoryCommand(
    string Name
) : IRequest<MessageResponse>;
