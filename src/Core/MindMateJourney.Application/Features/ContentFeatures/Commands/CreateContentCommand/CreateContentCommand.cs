using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.ContentFeatures.Commands.CreateContentCommand;

public sealed record CreateContentCommand(string Title, string Description, string CategoryId) : IRequest<MessageResponse>;

