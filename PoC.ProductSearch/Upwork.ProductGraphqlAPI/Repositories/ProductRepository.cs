namespace Upwork.ProductGraphqlAPI.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Product.Data;
    using Product.Domain;

    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;

        public ProductRepository(ProductContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetProductById(Guid id) =>
            await this.context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Color)
                    .Where(p => p.Id == id)
                    .SingleOrDefaultAsync();

        public IQueryable<Product> GetProducts() => 
            this.context.Products
                .Include(p => p.Category)
                .Include(p => p.Color);
    }
}