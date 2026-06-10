using System.ComponentModel.DataAnnotations;
using App.DataAccess.Entities.ViewModel;

namespace App.DataAccess.Entities.DBModel;

public class UserDBModel
{
    [Key]
    public int ID {get; set;}
    
    [Required]
    [MaxLength(150)]
    public string Name {get; set;} = string.Empty;
    
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Login { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string Password_hash { get; set; } = string.Empty;
    
    [Required]
    public string User_role { get; set; } = string.Empty;

    public static explicit operator UserViewModel(UserDBModel dBModel) => new UserViewModel(dBModel);
}