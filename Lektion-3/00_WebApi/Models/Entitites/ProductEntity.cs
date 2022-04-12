using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _00_WebApi.Models.Entitites
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNr { get; set; } = null!;
        
        [Required]
        public string Name { get; set; } = null!;
        
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
    }
}
