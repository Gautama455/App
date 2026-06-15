using App.DataAccess.Entities.DBModel;
using App.DataAccess.Repositories;
using App.ValidationAccess.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/validation")]
public class ValidationController : ControllerBase
{
    private UserRepository _repo;
    private ValidationService _validationService;

    public ValidationController(ValidationService service) => _validationService = service;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        UserDBModel result = _validationService.Validate(request) ? _repo.GetAllUsersAsync().Result.FirstOrDefault(u => u.Login.ToLower() == request.Login.ToLower()) : null;
        if (result == null) return Unauthorized("Пользователь не найден");
        if (result.Password_hash != request.Password) return Unauthorized("Неверный пароль");
        return Ok(new { Message = "Авторизация успешна!"});
    }
}
