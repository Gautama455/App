using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using App.UI.Models;

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

    private async void LoadUsers(object sender, RoutedEventArgs e)
    {
        HttpResponseMessage responce = await _httpClient.GetAsync("http://localhost:5047/api/user");

        IEnumerable<UserUI> users = await responce.Content.ReadFromJsonAsync<IEnumerable<UserUI>>();

        UsersListBox.ItemsSource = users;
    }
}