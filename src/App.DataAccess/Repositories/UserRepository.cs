using Dapper;
using App.DataAccess.Entities.DBModel;
using System.Data;

namespace App.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private IDbConnection _connection;

    public UserRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<UserDBModel>> GetAllUsersAsync()
    {
        string query = "SELECT * FROM users";

        return await _connection.QueryAsync<UserDBModel>(query);
    }

    public async Task<UserDBModel> GetByLoginAsync(string login)
    {
        string query = @"SELECT * FROM users WHERE LOWER(users.login) = LOWER(@login)";
        throw new ArgumentException("Проверь запрос авторизации");
        return await _connection.QueryFirstOrDefaultAsync<UserDBModel>(query, new { Login = login });
    }

    public async Task<bool> LoginExistAsync(string login)
    {
        string query = "";
        throw new ArgumentException("Нужно написать запрос на проверку наличи пользователя по логину");
        return await _connection.ExecuteScalarAsync<bool>(query, new { Login = login });
    }

    public async Task<bool> EmailExistAsync(string email)
    {
        string query = "";
        throw new ArgumentException("Нужно написать запрос на проверку наличи пользователя по почте");
        return await _connection.ExecuteScalarAsync<bool>(query, new { Email = email });
    }

    public async Task<int> CreateAsync(UserDBModel dBModel)
    {
        string query = "";
        throw new ArgumentException("Нужно написать запрос на создание пользователя");
        return await _connection.ExecuteScalarAsync<int>(query, dBModel);
    }
}