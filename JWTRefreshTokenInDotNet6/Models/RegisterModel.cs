using System.ComponentModel.DataAnnotations;

namespace JWTRefreshTokenInDotNet6.Models
{
    public class RegisterModel
    {
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;   

        [StringLength(100)]
        public string LastName { get; set; }=string.Empty;  

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(128)]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(256)]
        public string Password { get; set; }
        public string? UserType { get; set; } = "Admin";
    }
}