namespace WebApp.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Cart = new List<CartItem>();
        }

        public string? UserPrincipalName { get; set; }
        public List<CartItem> Cart { get; set; }
        public int TotalQuantity
        {
            get 
            {
                int _totalQuantity = 0;

                if (Cart.Count > 0)
                    foreach (var item in Cart)
                        _totalQuantity += item.Quantity;

                return _totalQuantity;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                decimal _totalPrice = 0;

                if (Cart.Count > 0)
                    foreach (var item in Cart)
                        _totalPrice += item.Product.Price * item.Quantity;

                return _totalPrice;
            }
        }
    }
}
