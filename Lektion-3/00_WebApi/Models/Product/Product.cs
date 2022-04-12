using System.ComponentModel.DataAnnotations;

namespace _00_WebApi.Models.Product
{
    public class Product
    {
        [Required]
        public string ArticleNumber { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }
    }
}
