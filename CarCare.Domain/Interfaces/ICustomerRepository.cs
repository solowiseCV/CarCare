using CarCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(Guid id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(Guid id);
    }
}
