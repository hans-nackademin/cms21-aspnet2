using AutoMapper;
using WebApp.Models;

namespace WebApp.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> GetAsync(int id);
        public Task<List<Product>> GetAsync();
    }

    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        private readonly IMapper _mapper;

        public ProductRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<Product> GetAsync(int id)
        {
            return _mapper.Map<Product>(await ReadAsync(id));
        }

        public async Task<List<Product>> GetAsync()
        {
            return _mapper.Map<List<Product>>(await ReadAsync());
        }
    }
}
