using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ShoppingCart shoppingCart;
            try { shoppingCart = JsonConvert.DeserializeObject<ShoppingCart>(HttpContext.Session.GetString("ShoppingCart")); }
            catch { shoppingCart = new ShoppingCart(); }

            if (!string.IsNullOrEmpty(User.Identity?.Name))
                shoppingCart.UserPrincipalName = User.Identity?.Name;

            var viewModel = new HomeIndexViewModel()
            {
                NewArrivals = await _productRepository.GetAsync(),
                ShoppingCart = shoppingCart
            };



            return View(viewModel);
        }










        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}