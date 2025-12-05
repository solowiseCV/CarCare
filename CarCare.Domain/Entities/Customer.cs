using System.ComponentModel.DataAnnotations;

namespace CarCare.Domain.Entities
{
    public class Customer : BaseEntity
    {

        public Guid UserId { get; set; }

        public string? DefaultAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }


}