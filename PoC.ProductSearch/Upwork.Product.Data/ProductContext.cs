namespace Upwork.Product.Data
{
    using System.Threading.Tasks;
    using Core.Data;
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class ProductContext : DbContext, IUnitOfWork
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Product> Products { get; set; }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductContext).Assembly);
        }
    }
}