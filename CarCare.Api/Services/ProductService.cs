using AutoMapper;
using CarCare.API.DTOS.Product.RequestDto;
using CarCare.API.DTOS.Product.ResponseDto;
using CarCare.Domain.Interfaces;
using CarCare.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.API.Services
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
            var products = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductResponseDto>>(products);
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return _mapper.Map<ProductResponseDto>(product);
        }

        public async Task<ProductResponseDto> CreateProductAsync(ProductRequestDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var newProduct = await _productRepository.AddProductAsync(product);
            return _mapper.Map<ProductResponseDto>(newProduct);
        }

        public async Task<bool> UpdateProductAsync(int id, ProductRequestDto productDto)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return false;
            }

            _mapper.Map(productDto, product);
            return await _productRepository.UpdateProductAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }
    }
}
