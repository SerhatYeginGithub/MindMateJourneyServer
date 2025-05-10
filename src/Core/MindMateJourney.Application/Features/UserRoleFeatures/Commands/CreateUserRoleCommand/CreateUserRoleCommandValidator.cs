using FluentValidation;

namespace MindMateJourney.Application.Features.UserRoleFeatures.Commands.CreateUserRoleCommand;

public sealed class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User id can not be empty");
        RuleFor(p => p.UserId).NotNull().WithMessage("Kullanıcı bilgisi boş olamaz!");
        RuleFor(p => p.RoleId).NotEmpty().WithMessage("Role bilgisi boş olamaz!");
        RuleFor(p => p.RoleId).NotNull().WithMessage("Role bilgisi boş olamaz!");
    }
}