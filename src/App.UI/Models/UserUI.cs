
using System.ComponentModel.DataAnnotations;

namespace App.UI.Models;

public class UserUI
{
    [Required]
    [MaxLength(150)]
    public string Name {get; set;} = string.Empty;
    
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Login { get; set; } = string.Empty;
}