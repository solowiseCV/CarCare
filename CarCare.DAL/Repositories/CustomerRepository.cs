using CarCare.DAL;
using CarCare.Domain.Entities;
using CarCare.Domain.Interfaces;

namespace CarCare.DAL.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Add any customer-specific method implementations here
    }
}
