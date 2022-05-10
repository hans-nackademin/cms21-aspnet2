using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebApp_IndividualAccounts.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = null!;
        
        [Required]
        public string LastName { get; set; } = null!;
    }
}
