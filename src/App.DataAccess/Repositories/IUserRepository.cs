using App.DataAccess.Entities.DBModel;

namespace App.DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<UserDBModel> GetByLoginAsync(string login);
        Task<IEnumerable<UserDBModel>> GetAllUsersAsync();
    }
}