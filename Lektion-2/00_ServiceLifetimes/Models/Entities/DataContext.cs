using Microsoft.EntityFrameworkCore;

namespace _00_ServiceLifetimes.Models.Entities
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<OrganizationEntity> Organizations { get; set; } = null!;
        public virtual DbSet<CustomerEntity> Customers { get; set; } = null!;
    }
}
