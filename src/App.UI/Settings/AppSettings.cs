namespace App.UI.Settings;

public class AppSettings
{
    public ApiUrl url { get; private set; } = new ApiUrl();
}

public class ApiUrl
{
    public string Users { get; set; } = string.Empty;
}