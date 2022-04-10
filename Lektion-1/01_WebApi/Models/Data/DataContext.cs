using _01_WebApi.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace _01_WebApi.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
    }
}
