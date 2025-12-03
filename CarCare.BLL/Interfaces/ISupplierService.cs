using CarCare.DTOs.Supplier.RequestDto;
using CarCare.DTOs.Supplier.ResponseDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.BLL.Interfaces
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
