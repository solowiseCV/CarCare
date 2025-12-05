using AutoMapper;
using CarCare.DTOs.Supplier.RequestDto;
using CarCare.DTOs.Supplier.ResponseDto;
using CarCare.Domain.Interfaces;
using CarCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarCare.BLL.Interfaces;

namespace CarCare.BLL.Services
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
            var suppliers = await _supplierRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<SupplierResponseDto>>(suppliers);
        }

        public async Task<SupplierResponseDto?> GetSupplierByIdAsync(Guid id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            return _mapper.Map<SupplierResponseDto>(supplier);
        }

        public async Task<SupplierResponseDto> CreateSupplierAsync(SupplierRequestDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);
            var newSupplier = await _supplierRepository.AddAsync(supplier);
            return _mapper.Map<SupplierResponseDto>(newSupplier);
        }

        public async Task UpdateSupplierAsync(Guid id, SupplierRequestDto supplierDto)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier == null)
            {
              
                return;
            }

            _mapper.Map(supplierDto, supplier);
            await _supplierRepository.UpdateAsync(supplier);
        }

        public async Task DeleteSupplierAsync(Guid id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier == null)
            {
             
                return;
            }
            await _supplierRepository.DeleteAsync(supplier);
        }
    }
}
