namespace Upwork.Product.Domain
{
    using System;
    using Core.Data;

    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Inventory { get; set; }
        public double Rating { get; set; }
        public string Brand { get; set; }
        public string PhotoPath { get; set; }
        public bool Available { get; set; }
        public DateTime Since { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ColorId { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
    }
}