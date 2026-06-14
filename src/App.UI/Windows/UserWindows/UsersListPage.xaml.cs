using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using App.UI.Models;

namespace App.UI.Windows;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class UsersListPage : Window
{
    private HttpClient _httpClient = new HttpClient();

    public UsersListPage()
    {
        InitializeComponent();
    }

    private async void LoadUsers(object sender, RoutedEventArgs reArgs)
    {
        HttpResponseMessage responce = await _httpClient.GetAsync(AppConfig.ApiEndpoints.Users);

        IEnumerable<UserUI> users = await responce.Content.ReadFromJsonAsync<IEnumerable<UserUI>>();

        UsersListBox.ItemsSource = users;
    }
}