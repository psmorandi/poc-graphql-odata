namespace Upwork.ProductGraphqlAPI.Queries
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HotChocolate.Types;
    using HotChocolate.Types.Relay;
    using Models;
    using Repositories;

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
        public IEnumerable<Product> GetProducts() => this.productRepository.GetProducts();

        public async Task<Product> GetProduct(string id) => await this.productRepository.GetProductById(id);

    }
}