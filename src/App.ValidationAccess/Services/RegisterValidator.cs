using App.ValidationAccess.Requests;
using FluentValidation;

namespace App.ValidationAccess.Services;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Имя не должно быть пустое");
        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Логин не должен быть пустым");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Почта обязательна");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Пароль не должен быть пустым");

    }
}