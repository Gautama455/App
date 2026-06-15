using System.ComponentModel.DataAnnotations;

public class LoginRequest
{
    [Required(ErrorMessage = "Логин обязателен")]
    public string Login { get; }
    [Required(ErrorMessage = "Пароль обязателен")]
    public string Password { get; }
}