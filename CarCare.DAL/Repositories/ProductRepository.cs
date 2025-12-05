using CarCare.DAL;
using CarCare.Domain.Entities;
using CarCare.Domain.Interfaces;

namespace CarCare.DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Add any product-specific method implementations here

    }
}
