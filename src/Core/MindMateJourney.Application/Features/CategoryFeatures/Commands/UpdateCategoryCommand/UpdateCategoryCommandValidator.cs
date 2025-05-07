using FluentValidation;

namespace MindMateJourney.Application.Features.CategoryFeatures.Commands.UpdateCategoryCommand;

public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Category ID cannot be empty.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Category name cannot be empty.")
            .MaximumLength(50).WithMessage("Category name must not exceed 50 characters.");
    }
}
