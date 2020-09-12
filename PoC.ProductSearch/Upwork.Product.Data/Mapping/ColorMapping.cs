namespace Upwork.Product.Data.Mapping
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ColorMapping: IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).IsRequired().HasColumnType("varchar(250)");
            builder.Property(c => c.Code).IsRequired().HasColumnType("int");

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Color)
                .HasForeignKey(p => p.ColorId);

            builder.ToTable("Colors");
        }
    }
}