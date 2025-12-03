using AutoMapper;
using CarCare.API.DTOS.Customer.RequestDto;
using CarCare.API.DTOS.Customer.ResponseDto;
using CarCare.Domain.Interfaces;
using CarCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerResponseDto>> GetCustomersAsync()
        {
            var customers = await _customerRepository.GetCustomersAsync();
            return _mapper.Map<IEnumerable<CustomerResponseDto>>(customers);
        }

        public async Task<CustomerResponseDto?> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            return _mapper.Map<CustomerResponseDto>(customer);
        }

        public async Task<CustomerResponseDto> CreateCustomerAsync(CustomerRequestDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            var newCustomer = await _customerRepository.AddCustomerAsync(customer);
            return _mapper.Map<CustomerResponseDto>(newCustomer);
        }

        public async Task<bool> UpdateCustomerAsync(Guid id, CustomerRequestDto customerDto)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return false;
            }

            _mapper.Map(customerDto, customer);
            return await _customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task<bool> DeleteCustomerAsync(Guid id)
        {
            return await _customerRepository.DeleteCustomerAsync(id);
        }
    }
}
