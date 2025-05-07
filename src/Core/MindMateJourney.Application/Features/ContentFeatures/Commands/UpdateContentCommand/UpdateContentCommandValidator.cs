using FluentValidation;

namespace MindMateJourney.Application.Features.ContentFeatures.Commands.UpdateContentCommand;

public sealed class UpdateContentCommandValidator : AbstractValidator<UpdateContentCommand>
{
    public UpdateContentCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.")
            .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid Id format.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must be at most 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(1000).WithMessage("Description must be at most 1000 characters.");

        RuleFor(x => x.CategoryId)
          .NotEmpty().WithMessage("CategoryId is required.")
          .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid CategoryId format.");
    }
}
