using WebApp.Models;

namespace WebApp.Services
{
    public interface IDataAccess
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();
        public Task<Product> GetProductAsync(int id);
        public Task<Product> CreateProductAsync(ProductCreateRequest data);

    }

}
