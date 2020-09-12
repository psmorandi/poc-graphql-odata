namespace Upwork.ProductGraphqlAPI.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Task<Product> GetProductById(string id);
    }
}