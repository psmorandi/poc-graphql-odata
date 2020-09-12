namespace Upwork.ProductGraphqlAPI.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Product.Data;
    using DomainProduct = Product.Domain.Product;

    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext context;
        private readonly IMapper mapper;

        public ProductRepository(ProductContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Product> GetProductById(string id) =>
            this.mapper.Map<DomainProduct, Product>(
                await this.context.Products
                    .Include(p => p.Category)
                    .Include(p => p.Color)
                    .Where(p => p.Id == Guid.Parse(id))
                    .SingleOrDefaultAsync());

        public IEnumerable<Product> GetProducts() =>
            this.mapper.Map<IEnumerable<DomainProduct>, IEnumerable<Product>>(this.context.Products
                .Include(p => p.Category)
                .Include(p => p.Color));
    }
}