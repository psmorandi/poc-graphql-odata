namespace Upwork.ProductGraphqlAPI.Mapping
{
    using AutoMapper;
    using Models;
    using DomainProduct = Product.Domain.Product;
    using DomainCategory = Product.Domain.Category;
    using DomainColor = Product.Domain.Color;

    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            this.CreateMap<DomainProduct, Product>()
                .ForMember(d => d.Id, 
                    opt => opt.MapFrom(src => src.Id.ToString()));
            
            this.CreateMap<DomainCategory, Category>();
            this.CreateMap<DomainColor, Color>();
        }
    }
}