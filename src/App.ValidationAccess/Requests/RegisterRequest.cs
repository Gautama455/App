namespace App.ValidationAccess.Requests;

public record RegisterRequest(string Name,string Login, string Email, string Password);