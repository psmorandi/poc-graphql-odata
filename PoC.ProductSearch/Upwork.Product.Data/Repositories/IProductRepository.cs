namespace Upwork.Product.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Data;
    using Domain;

    public interface IProductRepository: IRepository<Product>
    {
        Task<Product> GetProductById(Guid id);

        IQueryable<Product> GetProducts();
    }
}