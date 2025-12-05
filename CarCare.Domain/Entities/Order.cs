using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarCare.Domain.Entities
{

    public class Order : BaseEntity
    {

        public Guid UserId { get; set; }

        public string DeliveryAddress { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Status { get; set; } = "Pending";

        public bool InstallationRequested { get; set; } = false;
        public Guid? MechanicId { get; set; }
        public virtual Mechanic? Mechanic { get; set; }

        public DateTime? InstallationDate { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }

}
