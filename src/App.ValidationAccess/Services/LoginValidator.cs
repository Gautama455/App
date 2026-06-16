using App.ValidationAccess.Requests;
using FluentValidation;

namespace App.ValidationAccess.Services;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Login).NotEmpty().WithMessage("Логин обязателен");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Пароль обязателен");
    }
}
