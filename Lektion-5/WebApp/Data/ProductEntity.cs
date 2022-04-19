using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Data
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
