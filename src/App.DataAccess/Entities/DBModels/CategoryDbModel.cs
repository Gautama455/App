using System.ComponentModel.DataAnnotations;

namespace App.DataAccess.Entities.DBModel;

public class CategoryDbModel
{
    [Key]
    public int Id {get; set;}

    [Required]
    public string Name { get; set; } = string.Empty;
}