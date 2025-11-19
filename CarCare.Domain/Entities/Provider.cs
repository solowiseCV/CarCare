namespace CarCare.Domain.Entities
{
    public class Provider
    {
        public Guid Id { get; set; }
        public string BusinessName { get; set; } = null!;
        public string ServiceType { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
         
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation property to User
        // public Guid UserId { get; set; }
        // public User User { get; set; } = null!;
    }
}