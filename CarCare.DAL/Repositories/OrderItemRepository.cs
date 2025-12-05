using CarCare.DAL.Repositories;
using CarCare.Domain.Entities;
using CarCare.Domain.Interfaces;

namespace CarCare.DAL.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
