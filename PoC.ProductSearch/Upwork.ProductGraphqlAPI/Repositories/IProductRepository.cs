namespace Upwork.ProductGraphqlAPI.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Product.Domain;

    public interface IProductRepository
    {
        Task<Product> GetProductById(Guid id);

        IQueryable<Product> GetProducts();
    }
}