using App.DataAccess.Repositories;
using App.DataAccess.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using App.DataAccess.Entities.DBModel;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private UserRepository _repo;

    public UserController(UserRepository userRepository) => _repo = userRepository;

    [HttpGet]
    public async Task<IEnumerable<UserViewModel>> GetAllUsers()
    {
        IEnumerable<UserDBModel> res = await _repo.GetAllUsersAsync();
        return res.Select(item => (UserViewModel)item);
    }
}