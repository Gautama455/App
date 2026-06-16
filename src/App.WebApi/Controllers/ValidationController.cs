using App.DataAccess.Entities.DBModel;
using App.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using App.ValidationAccess.Requests;
using FluentValidation;
using App.ValidationAccess.Services;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("api/validation")]
public class ValidationController : ControllerBase
{
    private IUserRepository _repo;
    private IValidator<LoginRequest> _validator;
    private IPasswordHasher _hasher;

    public ValidationController
        (
            IUserRepository repo,
            IValidator<LoginRequest> validator,
            IPasswordHasher hasher
        )
    { _repo = repo; _validator = validator; _hasher = hasher; }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var isValid = await _validator.ValidateAsync(request);
        if (!isValid.IsValid) return BadRequest(isValid.Errors);

        var user = await _repo.GetByLoginAsync(request.Login);

        if (user is null) return Unauthorized("Пользователь не найден");
        if (!_hasher.Verify(request.Password, user.Password_hash)) return Unauthorized("Неверный пароль");
        return Ok(new {Message = "Неверный пароль"});
    }
}
