using CarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarCare.DAL.Entities; // Added for ApplicationUser

namespace CarCare.DAL.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);

            builder.HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<Customer>(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); // Assuming a User deleting means also deleting their Customer profile

            builder.Property(c => c.DefaultAddress)
                .HasMaxLength(500);

            builder.Property(c => c.City)
                .HasMaxLength(100);

            builder.Property(c => c.State)
                .HasMaxLength(100);
        }
    }
}