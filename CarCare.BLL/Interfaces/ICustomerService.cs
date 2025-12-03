using CarCare.DTOs.Customer.RequestDto;
using CarCare.DTOs.Customer.ResponseDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.BLL.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseDto>> GetCustomersAsync();
        Task<CustomerResponseDto?> GetCustomerByIdAsync(Guid id);
        Task<CustomerResponseDto> CreateCustomerAsync(CustomerRequestDto customerDto);
        Task<bool> UpdateCustomerAsync(Guid id, CustomerRequestDto customerDto);
        Task<bool> DeleteCustomerAsync(Guid id);
    }
}
