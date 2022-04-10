using System.ComponentModel.DataAnnotations;

namespace _00_ServiceLifetimes.Models.Entities
{
    public class OrganizationEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string OrganizationName { get; set; } = null!;
        public virtual ICollection<CustomerEntity> Customers { get; set; } = null!;
    }

}
