using FluentValidation;

namespace MindMateJourney.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshTokenCommand;


public sealed class CreateNewTokenByRefreshTokenCommandValidator : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
{
    public CreateNewTokenByRefreshTokenCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User bilgisi boş olamaz!");
        RuleFor(p => p.UserId).NotNull().WithMessage("User bilgisi boş olamaz!");
        RuleFor(p => p.RefreshToken).NotNull().WithMessage("Refresh Token bilgisi boş olamaz!");
        RuleFor(p => p.RefreshToken).NotEmpty().WithMessage("Refresh Token bilgisi boş olamaz!");
    }
}
