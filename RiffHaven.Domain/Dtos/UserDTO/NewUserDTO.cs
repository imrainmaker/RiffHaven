using System.ComponentModel.DataAnnotations;

namespace RiffHaven.Domain.Dtos.UserDTO
{
    public class NewUserDTO
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!]).{8,25}$")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string VerificationPassword { get; set; }
    }
}
