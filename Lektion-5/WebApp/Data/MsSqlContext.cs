using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class MsSqlContext : DbContext
    {
        public MsSqlContext()
        {              
        }

        public MsSqlContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
    }
}
