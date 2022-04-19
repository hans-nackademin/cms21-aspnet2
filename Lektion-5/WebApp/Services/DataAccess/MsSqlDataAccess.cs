using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Services.DataAccess
{
    public class MsSqlDataAccess : IDataAccess
    {
        private readonly MsSqlContext _context;
        private readonly IMapper _mapper;

        public MsSqlDataAccess(MsSqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Product> CreateProductAsync(ProductCreateRequest data)
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
