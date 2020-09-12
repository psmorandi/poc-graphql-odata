namespace Upwork.ProductGraphqlAPI.Models
{
    public class Product
    {
        public Category Category { get; set; }
        public Color Color { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
}