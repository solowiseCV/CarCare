using CarCare.API.DTOS.Customer.RequestDto;
using CarCare.API.DTOS.Customer.ResponseDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.API.Services
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
