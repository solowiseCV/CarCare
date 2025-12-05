using CarCare.DAL;
using CarCare.Domain.Entities;
using CarCare.Domain.Interfaces;

namespace CarCare.DAL.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Add any supplier-specific method implementations here
    }
}
