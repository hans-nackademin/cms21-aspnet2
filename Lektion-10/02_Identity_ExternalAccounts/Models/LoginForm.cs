using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace _02_Identity_ExternalAccounts.Models
{
    public class LoginForm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        public string ReturnUrl { get; set; } = "/";

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
