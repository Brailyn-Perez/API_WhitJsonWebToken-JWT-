
using System.ComponentModel.DataAnnotations;

namespace API_WhitJsonWebToken_JWT_.API.Entities;

public partial class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [MinLength(3)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(50)]
    [EmailAddress]
    public string? EMail { get; set; }

    [Required]
    [MaxLength(50)]
    [MinLength(10)]
    public string? Password { get; set; }

    public string? RefreshToken { get; internal set; }
    public DateTime? RefreshTokenExpiry { get; internal set; }
}
