using System.ComponentModel.DataAnnotations;

namespace _01_Identity_IndividualAccounts.Models
{
    public class RegisterForm
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public string ReturnUrl { get; set; } = "/";
    }
}
