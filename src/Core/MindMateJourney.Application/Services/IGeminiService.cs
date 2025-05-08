namespace MindMateJourney.Application.Services;

public interface IGeminiService
{
    Task<string> GenerateContentAsync(string prompt, CancellationToken cancellationToken);

}
