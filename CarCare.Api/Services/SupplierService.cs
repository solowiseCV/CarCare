using AutoMapper;
using CarCare.API.DTOS.Supplier.RequestDto;
using CarCare.API.DTOS.Supplier.ResponseDto;
using CarCare.Domain.Interfaces;
using CarCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.API.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierResponseDto>> GetSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetSuppliersAsync();
            return _mapper.Map<IEnumerable<SupplierResponseDto>>(suppliers);
        }

        public async Task<SupplierResponseDto?> GetSupplierByIdAsync(Guid id)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);
            return _mapper.Map<SupplierResponseDto>(supplier);
        }

        public async Task<SupplierResponseDto> CreateSupplierAsync(SupplierRequestDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            var newSupplier = await _supplierRepository.AddSupplierAsync(supplier);
            return _mapper.Map<SupplierResponseDto>(newSupplier);
        }

        public async Task<bool> UpdateSupplierAsync(Guid id, SupplierRequestDto supplierDto)
        {
            var supplier = await _supplierRepository.GetSupplierByIdAsync(id);
            if (supplier == null)
            {
                return false;
            }

            _mapper.Map(supplierDto, supplier);
            return await _supplierRepository.UpdateSupplierAsync(supplier);
        }

        public async Task<bool> DeleteSupplierAsync(Guid id)
        {
            return await _supplierRepository.DeleteSupplierAsync(id);
        }
    }
}
