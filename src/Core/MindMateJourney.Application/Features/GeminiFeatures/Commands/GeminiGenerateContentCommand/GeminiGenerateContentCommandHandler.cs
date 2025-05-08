using MediatR;
using MindMateJourney.Application.Services;

namespace MindMateJourney.Application.Features.GeminiFeatures.Commands.GeminiGenerateContentCommand;

public sealed class GeminiGenerateContentCommandHandler : IRequestHandler<GeminiGenerateContentCommand, string>
{
    private readonly IGeminiService _geminiService;
    public GeminiGenerateContentCommandHandler(IGeminiService geminiService)
    {
        _geminiService = geminiService;
    }
    public async Task<string> Handle(GeminiGenerateContentCommand request, CancellationToken cancellationToken)
    {
        return await _geminiService.GenerateContentAsync(request.prompt, cancellationToken);
    }
}
