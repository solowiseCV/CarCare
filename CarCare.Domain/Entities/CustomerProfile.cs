using System.ComponentModel.DataAnnotations;

namespace CarCare.Domain.Entities
{
public class Customer
{
    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? DefaultAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
    

}