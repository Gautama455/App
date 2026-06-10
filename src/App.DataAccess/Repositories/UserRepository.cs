using Dapper;
using Npgsql;
using App.DataAccess.Entities.DBModel;
using App.DataAccess.Entities.ViewModel;

namespace App.DataAccess.Repositories;

public class UserRepository
{
    private string _connectionString;

    public UserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<UserViewModel>>? GetAllUsersAsync()
    {
        await using NpgsqlConnection sqlConnection = new NpgsqlConnection(_connectionString);
        string query = "SELECT * FROM users";
        IEnumerable<UserDBModel> result = await sqlConnection.QueryAsync<UserDBModel>(query);
        return result.Select(item => (UserViewModel)item);
    }
}