using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ecommerce.Infrastructure
{
    public class EcommerceDbContextFactory : IDesignTimeDbContextFactory<EcommerceDbContext>
    {
        public EcommerceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EcommerceDbContext>();

            // Connection string dùng cho migration
            // Catched
            optionsBuilder.UseSqlServer("...");

            return new EcommerceDbContext(optionsBuilder.Options);
        }
    }
}
