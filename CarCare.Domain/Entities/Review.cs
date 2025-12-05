using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarCare.Domain.Entities
{

    public class Review : BaseEntity
    {

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        public Guid UserId { get; set; }

        [Required, Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }
    }

}
