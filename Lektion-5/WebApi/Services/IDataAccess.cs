using WebApi.Models;

namespace WebApi.Services
{
    public interface IDataAccess
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<Product> GetProductAsync(int id);
        public Task<Product> CreateProductAsync(ProductRequest data);
    }
}
