using FluentValidation;

namespace MindMateJourney.Application.Features.RoleFeatures.Commands.CreateRoleCommand;

public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Role name can not be empty");
        RuleFor(p => p.Name).NotNull().WithMessage("Role name can not be empty");
    }
}