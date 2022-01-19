using Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configuration
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> productBuilder)
        {
            productBuilder.ToTable("Products");

            productBuilder.Property(x => x.Id)
                 .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            productBuilder.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            productBuilder.Property(x => x.Description)
                .HasMaxLength(500);

            productBuilder.Property(x => x.ImageUrl)
                .HasMaxLength(100)
                .IsRequired();

            productBuilder.Property(x => x.Barcode)
                .HasMaxLength(200)
                .IsRequired();

            productBuilder.Property(x => x.Amount)
                .IsRequired();

            productBuilder.Property(x => x.Price)
                .IsRequired();

            productBuilder.Property(x => x.Currency)
                .HasMaxLength(3)
                .IsRequired();
        }
    }
}
