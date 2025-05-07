using FluentValidation;

namespace MindMateJourney.Application.Features.ContentFeatures.Commands.CreateContentCommand;

public sealed class CreateContentCommandValidator : AbstractValidator<CreateContentCommand>
{
    public CreateContentCommandValidator()
    {
        RuleFor(x => x.Title)
           .NotEmpty().WithMessage("Title is required.")
           .Length(5, 100).WithMessage("Title must be between 5 and 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .Length(10, 500).WithMessage("Description must be between 10 and 500 characters.");

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID must not be empty.")
            .Must(id => Guid.TryParse(id, out _))
            .WithMessage("Category ID must be a valid value.");
    }
}
