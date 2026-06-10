using System.Windows;
using Microsoft.Extensions.Configuration;
using App.UI.Settings;

namespace App.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IConfiguration Configuration { get; protected set; }
    public static AppSettings Settings { get; protected set; }

    protected override void OnStartup(StartupEventArgs eargs)
    {
        base.OnStartup(eargs);

        Configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true)
            .Build();

        Settings = new AppSettings();
        Configuration.Bind(Settings);

        var window = new MainWindow();
        window.Show();
    }
}

