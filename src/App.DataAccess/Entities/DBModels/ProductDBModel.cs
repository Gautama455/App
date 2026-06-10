using System.ComponentModel.DataAnnotations;

namespace App.DataAccess.Entities.DBModel;

public class ProductDBModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name {get; set; } = string.Empty;
    
    public decimal Price { get; set; }
    
    [MaxLength(255)]
    public string PhotoUrl { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public int CategoryId { get; set; }
    
    [MaxLength(50)]
    public string Provider { get; set;} = string.Empty;
    
    [MaxLength(50)]
    public string Brand { get; set; } = string.Empty;
    
    [Range(0, 100)]
    public decimal Discount { get; set; }

    [MaxLength(10)]
    public string Unit {get; set;} = string.Empty;
}