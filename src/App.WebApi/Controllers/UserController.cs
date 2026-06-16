using App.DataAccess.Entities.ViewModel;
using App.DataAccess.Entities.DBModel;
using App.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private IUserRepository _repo;

    public UserController(IUserRepository userRepository) => _repo = userRepository;

    [HttpGet]
    public async Task<IEnumerable<UserViewModel>> GetAllUsers()
    {
        IEnumerable<UserDBModel> res = await _repo.GetAllUsersAsync();
        return res.Select(item => (UserViewModel)item);
    }
}