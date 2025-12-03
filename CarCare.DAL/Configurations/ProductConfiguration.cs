using CarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarCare.DAL.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(500);

            builder.Property(p => p.CarMake)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.CarModel)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.CarYear)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.AuthenticityCertificateUrl)
                .HasMaxLength(500);
        }
    }
}