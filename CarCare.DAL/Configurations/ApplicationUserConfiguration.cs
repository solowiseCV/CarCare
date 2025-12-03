using CarCare.DAL.Entities;
using CarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarCare.DAL.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.Name).HasMaxLength(100);
            builder.Property(u => u.Address).HasMaxLength(200);
            builder.Property(u => u.Gender).HasMaxLength(50);
            builder.Property(u => u.ProfilePictureUrl).HasMaxLength(500);

            builder.HasOne(u => u.SupplierProfile)
                .WithOne()
                .HasForeignKey<Supplier>(s => s.UserId);

            builder.HasOne(u => u.CustomerProfile)
                .WithOne()
                .HasForeignKey<Customer>(c => c.UserId);

            builder.HasOne(u => u.MechanicProfile)
                .WithOne()
                .HasForeignKey<Mechanic>(m => m.UserId);
        }
    }
}
