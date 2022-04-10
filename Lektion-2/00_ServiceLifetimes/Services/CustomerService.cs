using _00_ServiceLifetimes.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _00_ServiceLifetimes.Services
{
    public interface ICustomerService : ICrud
    {

    }

    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync<T>()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            return (IEnumerable<T>)await _context.Customers.ToListAsync();
        }

        public async Task<T> GetAsync<T>(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync<T>(T model)
        {
            throw new NotImplementedException();
        }
    }
}
