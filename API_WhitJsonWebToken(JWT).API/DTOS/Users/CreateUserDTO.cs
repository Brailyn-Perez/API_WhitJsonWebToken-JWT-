using System.ComponentModel.DataAnnotations;

namespace API_WhitJsonWebToken_JWT_.API.DTOS.Users
{
    public class CreateUserDTO
    {
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
    }
}
