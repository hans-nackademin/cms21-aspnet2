using _01_WebApi.Models;
using _01_WebApi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace _01_WebApi.Services
{
    public interface IProductManager 
    {
        Task<IEnumerable<Product>> GetProductsAsync();
    }

    public class ProductManager : IProductManager
    {
        private readonly DataContext _context;

        public ProductManager(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var list = new List<Product>();
            foreach (var product in await _context.Products.ToListAsync())
                list.Add(new Product { Id = product.Id, Name = product.Name, Price = product.Price });

            return list;
        }
    }
}
