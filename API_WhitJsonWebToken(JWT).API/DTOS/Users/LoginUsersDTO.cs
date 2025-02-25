using System.ComponentModel.DataAnnotations;

namespace API_WhitJsonWebToken_JWT_.API.DTOS.Users
{
    public class LoginUsersDTO
    {
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
