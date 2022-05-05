using System.ComponentModel.DataAnnotations;

namespace _02_Identity_ExternalAccounts.Models
{
    public class UserProfileEntity
    {
        [Key]
        public string UserId { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;
    }
}
