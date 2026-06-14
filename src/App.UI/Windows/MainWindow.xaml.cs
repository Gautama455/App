using System.Net.Http;
using System.Windows;

namespace App.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private HttpClient _httpClient = new HttpClient();

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Login(object sender, RoutedEventArgs e)
    {
        await PostAsync(AppConfig.ApiEndpoints.Login, new { Login = TextBoxLogin.Text, Password = TextBoxPassword.Text });
    }

    private async void LoginAsGuest(object sender, RoutedEventArgs e)
    {
        await PostAsync(AppConfig.ApiEndpoints.LoginAsGuest, new {});
    }

    private async void Register(object sender, RoutedEventArgs e)
    {
        await PostAsync(AppConfig.ApiEndpoints.Register, new {Login = TextBoxLogin.Text, Password = TextBoxPassword.Text});
    }

    private async Task PostAsync(string url, object data)
    {
        var responce = await _httpClient.PostAsync(
            url,
            new StringContent
            (
                System.Text.Json.JsonSerializer.Serialize(data),
                System.Text.Encoding.UTF8, "application/json"
            )
        );

    }
}