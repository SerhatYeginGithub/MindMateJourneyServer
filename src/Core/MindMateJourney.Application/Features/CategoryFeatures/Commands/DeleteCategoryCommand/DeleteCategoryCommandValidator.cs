using FluentValidation;

namespace MindMateJourney.Application.Features.CategoryFeatures.Commands.DeleteCategoryCommand;

public sealed class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Category ID must not be empty.")
            .Must(id => Guid.TryParse(id, out _))
            .WithMessage("Category ID must be a valid value.");
    }
}
