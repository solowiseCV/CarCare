using CarCare.API.DTOS.Supplier.RequestDto;
using CarCare.API.DTOS.Supplier.ResponseDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.API.Services
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierResponseDto>> GetSuppliersAsync();
        Task<SupplierResponseDto?> GetSupplierByIdAsync(Guid id);
        Task<SupplierResponseDto> CreateSupplierAsync(SupplierRequestDto supplierDto);
        Task<bool> UpdateSupplierAsync(Guid id, SupplierRequestDto supplierDto);
        Task<bool> DeleteSupplierAsync(Guid id);
    }
}
