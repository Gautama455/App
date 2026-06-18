using App.DataAccess.Entities.DBModel;

namespace App.WebApi.Services;

public interface IJwtService
{
    string GenerateToken(UserDBModel dbModel);
}