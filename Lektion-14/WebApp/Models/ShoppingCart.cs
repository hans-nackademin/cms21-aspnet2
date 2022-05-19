namespace WebApp.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Cart = new();
        }

        public string? UserPrincipalName { get; set; }
        public List<CartItem> Cart { get; set; }
        public int TotalQuantity
        {
            get
            {
                int _total = 0;

                if (Cart.Count > 0)
                    foreach(var item in Cart)
                        _total += item.Quantity;

                return _total;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                decimal _total = 0;

                if (Cart.Count > 0)
                    foreach (var item in Cart)
                        _total += item.Product.Price * item.Quantity;

                return _total;
            }
        }
    }
}
