using System.ComponentModel.DataAnnotations;

namespace _00_ServiceLifetimes.Models.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public int OrganizationId { get; set; }
        public virtual OrganizationEntity Organization { get; set; } = null!;

    }

}
