using App.DataAccess.Repositories;
using App.DataAccess.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using App.DataAccess.Entities.DBModel;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private UserRepository _repo;

    public UserController(UserRepository userRepository) => _repo = userRepository;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<UserViewModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
    {
        return Ok(await _repo.GetAllUsersAsync());
    }
}