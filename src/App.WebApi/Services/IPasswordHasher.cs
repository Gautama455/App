namespace App.WebApi.Services;

public interface IPasswordHasher
{
    string Hash(string pass);
    bool Verify(string pass, string hash);
}