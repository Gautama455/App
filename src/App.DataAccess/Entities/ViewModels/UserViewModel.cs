using System.ComponentModel.DataAnnotations;
using App.DataAccess.Entities.DBModel;

namespace App.DataAccess.Entities.ViewModel;

public class UserViewModel
{
    [Required]
    [MaxLength(150)]
    public string Name { get; set;} = string.Empty;
    
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(100)]
    public string Login { get; set; } = string.Empty;

    public UserViewModel(UserDBModel dBModel)
    {
        Name = dBModel.Name;
        Email = dBModel.Email;
        Login = dBModel.Login;
    }
}