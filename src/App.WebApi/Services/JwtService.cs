using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.DataAccess.Entities.DBModel;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace App.WebApi.Services;

public class JwtService : IJwtService
{
    private IConfiguration _config;

    public JwtService(IConfiguration configuration) => _config = configuration;

    public string GenerateToken(UserDBModel dbModel)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, dbModel.Name.ToString()),
            new Claim(ClaimTypes.Name, dbModel.Login),
            new Claim(ClaimTypes.Email, dbModel.Email ?? string.Empty),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audence"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}