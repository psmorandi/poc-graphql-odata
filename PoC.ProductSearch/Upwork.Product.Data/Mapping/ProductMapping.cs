namespace Upwork.Product.Data.Mapping
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductMapping : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Available).IsRequired().HasColumnType("bit");
            builder.Property(p => p.Brand).IsRequired().HasColumnType("varchar(250)");
            builder.Property(p => p.Description).IsRequired().HasColumnType("varchar(500)");
            builder.Property(p => p.Inventory).IsRequired().HasColumnType("bigint");
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(250)");
            builder.Property(p => p.PhotoPath).IsRequired(false).HasColumnType("varchar(250)");
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.Rating).IsRequired().HasColumnType("float");
            builder.Property(p => p.Since).IsRequired().HasColumnType("datetime");
            builder.Property(p => p.Size).IsRequired().HasColumnType("int");

            builder.ToTable("Products");
        }
    }
}