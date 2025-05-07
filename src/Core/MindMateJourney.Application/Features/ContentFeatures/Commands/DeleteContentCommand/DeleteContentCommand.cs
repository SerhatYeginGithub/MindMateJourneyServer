using MediatR;
using MindMateJourney.Application.DTOS;

namespace MindMateJourney.Application.Features.ContentFeatures.Commands.DeleteContentCommand;

public sealed record DeleteContentCommand(string Id) : IRequest<MessageResponse>;
