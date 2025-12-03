using CarCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetSuppliersAsync();
        Task<Supplier?> GetSupplierByIdAsync(Guid id);
        Task<Supplier> AddSupplierAsync(Supplier supplier);
        Task<bool> UpdateSupplierAsync(Supplier supplier);
        Task<bool> DeleteSupplierAsync(Guid id);
    }
}
