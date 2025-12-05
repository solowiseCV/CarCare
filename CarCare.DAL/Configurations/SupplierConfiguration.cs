using CarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarCare.DAL.Entities;

namespace CarCare.DAL.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers");

            builder.HasKey(s => s.Id);

            builder.HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<Supplier>(s => s.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(s => s.CompanyName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.ContactPerson)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.Address)
                .HasMaxLength(500);

            builder.Property(s => s.City)
                .HasMaxLength(100);

            builder.Property(s => s.State)
                .HasMaxLength(100);

            builder.Property(s => s.BusinessRegistrationNumber)
                .HasMaxLength(100);

            builder.Property(s => s.ImportLicenseNumber)
                .HasMaxLength(100);

            builder.Property(s => s.AverageRating)
                .HasColumnType("decimal(3,2)");

            builder.Property(s => s.OnTimeDeliveryRate)
                .HasColumnType("decimal(5,2)");

            builder.HasMany(s => s.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId);
        }
    }
}