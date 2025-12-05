using AutoMapper;
using CarCare.DTOs.Product.RequestDto;
using CarCare.DTOs.Product.ResponseDto;
using CarCare.Domain.Interfaces;
using CarCare.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarCare.BLL.Interfaces;

namespace CarCare.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetProductsAsync()
        {
            var products = await _productRepository.ListAllAsync();
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<ProductResponseDto> CreateProductAsync(ProductRequestDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var newProduct = await _productRepository.AddAsync(product);
            return _mapper.Map<ProductResponseDto>(newProduct);
        }

        public async Task UpdateProductAsync(Guid id, ProductRequestDto productDto)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
               
                return;
            }

            _mapper.Map(productDto, product);
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
             
                return;
            }
            await _productRepository.DeleteAsync(product);
        }
    }
}
