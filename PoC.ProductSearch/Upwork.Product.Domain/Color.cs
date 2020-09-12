namespace Upwork.Product.Domain
{
    using System.Collections.Generic;
    using Core.Data;

    public class Color : Entity
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}