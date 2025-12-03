using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarCare.Domain.Entities
{
 public class OrderItem
{
    [Key]
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }
    public virtual Order Order { get; set; } = null!;

    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal UnitPrice { get; set; }
}

}
