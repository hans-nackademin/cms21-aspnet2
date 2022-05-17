namespace WebApp.Models
{
    public class HomeIndexViewModel
    {
        public List<Product> NewArrivals { get; set; } = null!;
        public ShoppingCart ShoppingCart { get; set; } = null!;
    }
}
