using Microsoft.EntityFrameworkCore;

namespace _00_WebApi.Models.Entitites
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
    }
}
