using App.DataAccess.Entities.DBModel;
using App.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using App.ValidationAccess.Requests;
using FluentValidation;
using App.WebApi.Services;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[AllowAnonymous]
[Route("api/validation")]
public class ValidationController : ControllerBase
{
    private IUserRepository _repo;
    private IValidator<LoginRequest> _loginValidator;
    private IValidator<RegisterRequest> _registerValidator;
    private IPasswordHasher _hasher;
    private IXamlComposer _composer;

    public ValidationController
        (
            IUserRepository repo,
            IValidator<LoginRequest> loginValidator,
            IValidator<RegisterRequest> registerValidator,
            IPasswordHasher hasher,
            IXamlComposer composer
        )
    { _repo = repo; _loginValidator = loginValidator; _registerValidator = registerValidator; _hasher = hasher; _composer = composer; }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var isValid = await _loginValidator.ValidateAsync(request);
        if (!isValid.IsValid) return BadRequest(isValid.Errors);

        var user = await _repo.GetByLoginAsync(request.Login);

        if (user is null) return Unauthorized("Пользователь не найден");
        if (!_hasher.Verify(request.Password, user.Password_hash)) return Unauthorized("Неверный пароль");

        var uiPage = _composer.ComposePageAsync();

        return Ok(
            new
            {
                User = new { user.Name, user.Login, user.Email },
                UI = uiPage
            }
        );
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var isValid = await _registerValidator.ValidateAsync(request);

        if (!isValid.IsValid) return BadRequest(isValid.Errors);

        if (await _repo.LoginExistAsync(request.Login)) return Conflict(new { Field = "Login", Message = "Логин уже используется" });
        if (await _repo.EmailExistAsync(request.Email)) return Conflict(new { Field = "Email", Message = "Email уже используется" });

        string passwordHash = _hasher.Hash(request.Password);

        await _repo.CreateAsync
        (
            new UserDBModel
            {
                Name = request.Name,
                Login = request.Login,
                Password_hash = passwordHash,
                Email = request.Email
            }
        );

        return Ok(new { Message = "Регистрация успешна" });
    }
}
