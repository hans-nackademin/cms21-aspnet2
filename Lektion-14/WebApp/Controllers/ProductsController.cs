using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var shoppingCart = new ShoppingCart();
            var sessionShoppingCart = HttpContext.Session.GetString("ShoppingCart");

            if (!string.IsNullOrEmpty(sessionShoppingCart)) 
            {
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(sessionShoppingCart);
                var index = shoppingCart.Cart.FindIndex(x => x.Product.Id == id);

                if (index > -1)
                    shoppingCart.Cart[index].Quantity += 1;
                else
                    shoppingCart.Cart.Add(new CartItem { Product = await _productRepository.GetAsync(id) });
            }
            else
            {
                shoppingCart.Cart.Add(new CartItem { Product = await _productRepository.GetAsync(id) });
            }

            HttpContext.Session.SetString("ShoppingCart", JsonConvert.SerializeObject(shoppingCart));
            ViewData["ShoppingCart"] = HttpContext.Session.GetString("ShoppingCart");

            return View();
        }


        public async Task<IActionResult> Details(int id)
        {
            ShoppingCart shoppingCart;
            try { shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Session.GetString("ShoppingCart")); }
            catch { shoppingCart = new(); }

            var viewModel = new ProductViewModel
            {
                Product = await _productRepository.GetAsync(id),
                ShoppingCart = shoppingCart
            };

            return View(viewModel);
        }
    }
}
