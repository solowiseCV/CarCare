using CarCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarCare.DAL.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.UnitPrice)
                .HasColumnType("decimal(10,2)");

            builder.HasOne(oi => oi.Product)
                .WithMany() // Assuming Product doesn't have a navigation property for OrderItems
                .HasForeignKey(oi => oi.ProductId);
        }
    }
}