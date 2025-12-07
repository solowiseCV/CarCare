using System.ComponentModel.DataAnnotations;

namespace CarCare.DTOs.Product.RequestDto
{
    public class ProductRequestDto
    {
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }
        [StringLength(1000)]
        public string? Description { get; set; }
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
    }
}
