namespace WebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; }
        public string? ImageUrl { get; set; }
    }
}
