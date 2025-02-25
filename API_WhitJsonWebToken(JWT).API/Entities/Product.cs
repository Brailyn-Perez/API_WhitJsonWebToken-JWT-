
using System.ComponentModel.DataAnnotations;

namespace API_WhitJsonWebToken_JWT_.API.Entities;

public partial class Product
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    [MinLength(3)]
    public string? Name { get; set; }
    [Required]
    [MaxLength(50)]
    [MinLength(3)]
    public string? Brand { get; set; }
    [Required]
    [MaxLength(10)]
    public decimal? Price { get; set; }
}
