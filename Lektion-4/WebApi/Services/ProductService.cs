using WebApi.Models;

namespace WebApi.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();
    }

    public class ProductService : IProductService
    {
        public ProductService()
        {

        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
