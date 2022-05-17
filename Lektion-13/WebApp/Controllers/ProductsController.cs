using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int id)
        {
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0

            var shoppingCart = new ShoppingCart();

            var cartSession = HttpContext.Session.GetString("ShoppingCart");
            if (!string.IsNullOrEmpty(cartSession))
            {
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(cartSession);

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
            return RedirectToAction("Index", "Home");
        }

    }
}
