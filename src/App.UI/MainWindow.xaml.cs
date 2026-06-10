using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using App.UI.Settings;

namespace App.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ApiService _apiService = new ApiService();

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void LoadUsers()
    {
        UsersListBox.ItemsSource = await _apiService.GetUsers();
    }
}