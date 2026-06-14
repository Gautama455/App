using System.IO;
using Microsoft.Extensions.Configuration;

public class AppConfig
{
    public static ApiEndpoints ApiEndpoints { get;}
    static AppConfig()
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile
            (
                path: Path.Combine(AppContext.BaseDirectory, "appsettings.json"),
                optional: false,
                reloadOnChange: true
            )
            .Build();
        
        ApiEndpoints = configuration.GetSection("ApiEndpoints").Get<ApiEndpoints>();
    }
}

public class ApiEndpoints
{
    public string Users { get; }
    public string Login { get; }
    public string LoginAsGuest { get; }
    public string Register { get; }
}