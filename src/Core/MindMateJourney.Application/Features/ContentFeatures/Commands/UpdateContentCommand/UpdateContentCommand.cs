using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.ContentFeatures.Commands.UpdateContentCommand;

public sealed record UpdateContentCommand(string Id, string Title, string Description, string CategoryId) : IRequest<MessageResponse>;
