using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarCare.Domain.Entities
{
   public class Product
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    public Guid SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; } = null!;

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    public int Stock { get; set; } = 0;

    public string? ImageUrl { get; set; }

    [MaxLength(100)]
    public string CarMake { get; set; } = string.Empty;

    [MaxLength(100)]
    public string CarModel { get; set; } = string.Empty;

    [MaxLength(20)]
    public string CarYear { get; set; } = string.Empty;


    public bool IsAuthentic { get; set; } = true;
    public string? AuthenticityCertificateUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
}
