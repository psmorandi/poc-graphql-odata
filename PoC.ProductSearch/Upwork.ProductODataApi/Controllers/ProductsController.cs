namespace Upwork.ProductODataApi.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using Product.Data.Repositories;
    using Product.Domain;

    [Route("odata/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class ProductsController : ODataController
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<Product> GetProducts() => this.productRepository.GetProducts();
    }
}