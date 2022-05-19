namespace WebApp.Models
{
    public class HomeViewModel
    {
        public List<Product> Products { get; set; } = null!;
        public ShoppingCart ShoppingCart { get; set; } = null!;
    }
}
