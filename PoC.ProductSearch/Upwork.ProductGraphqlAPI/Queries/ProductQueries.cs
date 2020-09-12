namespace Upwork.ProductGraphqlAPI.Queries
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using HotChocolate.Types;
    using HotChocolate.Types.Relay;
    using Product.Data.Repositories;
    using Product.Domain;

    [ExtendObjectType(Name = "Query")]
    public class ProductQueries
    {
        private readonly IProductRepository productRepository;

        public ProductQueries(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Product> GetProducts() => this.productRepository.GetProducts();

        public async Task<Product> GetProduct(Guid id) => await this.productRepository.GetProductById(id);

    }
}