using FluentValidation;

namespace MindMateJourney.Application.Features.ContentFeatures.Commands.DeleteContentCommand;

public sealed class DeleteContentCommandValidator : AbstractValidator<DeleteContentCommand>
{
    public DeleteContentCommandValidator()
    {
        RuleFor(x => x.Id)
         .NotEmpty().WithMessage("Id is required.")
         .NotNull().WithMessage("Id cannot be null.")
         .Must(id => Guid.TryParse(id, out _)).WithMessage("Invalid Id format.");
    }
}
