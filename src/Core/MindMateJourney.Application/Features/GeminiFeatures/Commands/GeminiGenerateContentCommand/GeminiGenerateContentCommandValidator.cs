using FluentValidation;

namespace MindMateJourney.Application.Features.GeminiFeatures.Commands.GeminiGenerateContentCommand;

public sealed class GeminiGenerateContentCommandValidator : AbstractValidator<GeminiGenerateContentCommand>
{
    public GeminiGenerateContentCommandValidator()
    {
        RuleFor(x => x.prompt)
            .NotEmpty()
            .WithMessage("Prompt cannot be empty.")
            .MaximumLength(500)
            .WithMessage("Prompt cannot exceed 500 characters.");
    }
}
