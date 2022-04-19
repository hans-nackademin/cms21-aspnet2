using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Services
{
    public class SqlDataAccess : IDataAccess
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SqlDataAccess(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> CreateProductAsync(ProductRequest data)
        {
            var productEntity = _mapper.Map<ProductEntity>(data);
            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<Product>(productEntity);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return _mapper.Map<IEnumerable<Product>>(await _context.Products.ToListAsync());
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return _mapper.Map<Product>(await _context.Products.FindAsync(id));
        }
    }
}
