using App.DataAccess.Repositories;
using App.DataAccess.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private UserRepository _repo;

    public UserController(UserRepository userRepository) => _repo = userRepository;

    [HttpGet]
    public async Task<IEnumerable<UserViewModel>> GetAllUsers()
    {
        return await _repo.GetAllUsersAsync();
    }
}