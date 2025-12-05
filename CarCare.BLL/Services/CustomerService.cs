using AutoMapper;
using CarCare.DTOs.Customer.RequestDto;
using CarCare.DTOs.Customer.ResponseDto;
using CarCare.Domain.Interfaces;
using CarCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarCare.BLL.Interfaces;

namespace CarCare.BLL.Services
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
            var customers = await _customerRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<CustomerResponseDto>>(customers);
        }

        public async Task<CustomerResponseDto?> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            return _mapper.Map<CustomerResponseDto>(customer);
        }

        public async Task<CustomerResponseDto> CreateCustomerAsync(CustomerRequestDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            var newCustomer = await _customerRepository.AddAsync(customer);
            return _mapper.Map<CustomerResponseDto>(newCustomer);
        }

        public async Task UpdateCustomerAsync(Guid id, CustomerRequestDto customerDto)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
               
                return;
            }

            _mapper.Map(customerDto, customer);
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
             
                return;
            }
            await _customerRepository.DeleteAsync(customer);
        }
    }
}
