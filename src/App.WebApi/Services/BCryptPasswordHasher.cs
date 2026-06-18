namespace App.WebApi.Services;

public class BCryptPasswordHasher : IPasswordHasher
{
    public string Hash(string pass) => BCrypt.Net.BCrypt.HashPassword(pass, 12);
    public bool Verify(string pass, string hash) => BCrypt.Net.BCrypt.Verify(pass, hash);
}