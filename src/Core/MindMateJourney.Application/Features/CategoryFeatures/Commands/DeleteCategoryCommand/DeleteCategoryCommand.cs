using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.CategoryFeatures.Commands.DeleteCategoryCommand;

public sealed record DeleteCategoryCommand(string Id) : IRequest<MessageResponse>;