using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.UnitTests.Fixtures
{
    public static class ProductsFixtures
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 1000 },
            new Product { Id = 2, Name = "Product 2", Price = 2000 },
            new Product { Id = 3, Name = "Product 3", Price = 3000 },
            new Product { Id = 4, Name = "Product 4", Price = 4000 },
            new Product { Id = 5, Name = "Product 5", Price = 5000 },
        };

        public static async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            await Task.Delay(800);
            return _products;
        }

        public static async Task<Product> GetProductAsync(int id)
        {
            await Task.Delay(500);
            return _products.FirstOrDefault(x => x.Id == id);
        }

        public static async Task<Product> CreateProductAsync(ProductCreateRequest data)
        {
            var id = _products.Count() + 1;
            var product = new Product { Id = id, Name = data.Name, Price = data.Price };
            await Task.Delay(500);
            return product;
        }
    }
}
