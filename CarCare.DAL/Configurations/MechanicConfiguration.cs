using CarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarCare.DAL.Entities; 

namespace CarCare.DAL.Configurations
{
    public class MechanicConfiguration : IEntityTypeConfiguration<Mechanic>
    {
        public void Configure(EntityTypeBuilder<Mechanic> builder)
        {
            builder.ToTable("Mechanics");

            builder.HasKey(m => m.Id);

            builder.HasOne<ApplicationUser>()
                .WithOne()
                .HasForeignKey<Mechanic>(m => m.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); 

            builder.Property(m => m.WorkshopName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(m => m.Address)
                .HasMaxLength(500);

            builder.Property(m => m.City)
                .HasMaxLength(100);

            builder.Property(m => m.State)
                .HasMaxLength(100);

            builder.Property(m => m.VerificationDocumentUrl)
                .HasMaxLength(500);

            builder.Property(m => m.Rating)
                .HasColumnType("decimal(3,2)");
        }
    }
}