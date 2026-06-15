namespace App.ValidationAccess.Services;

public class ValidationService
{
    public bool Validate(LoginRequest request) => 
        request != null
        && !string.IsNullOrEmpty(request.Login)
        && !string.IsNullOrEmpty(request.Password);

}
