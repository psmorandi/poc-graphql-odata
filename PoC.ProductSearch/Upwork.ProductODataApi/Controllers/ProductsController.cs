namespace Upwork.ProductODataApi.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNetCore.Mvc;
    using Product.Data;
    using Product.Domain;

    [Route("odata/[controller]")]
    [ApiExplorerSettings(IgnoreApi = false)]
    public class ProductsController : ODataController
    {
        private readonly ProductContext productContext;

        public ProductsController(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<Product> GetProducts()
        {
            return this.productContext.Products;
        }
    }
}