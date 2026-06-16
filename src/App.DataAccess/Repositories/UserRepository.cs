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


        return await _connection.QueryFirstOrDefaultAsync<UserDBModel>(query, new {Login = login});
    }
}