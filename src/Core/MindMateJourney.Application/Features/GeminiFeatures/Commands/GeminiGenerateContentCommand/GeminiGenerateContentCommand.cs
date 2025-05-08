using MediatR;

namespace MindMateJourney.Application.Features.GeminiFeatures.Commands.GeminiGenerateContentCommand;

public sealed record GeminiGenerateContentCommand(string prompt) : IRequest<string>;
