using CarCare.API.DTOS.Product.RequestDto;
using CarCare.API.DTOS.Product.ResponseDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.API.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetProductsAsync();
        Task<ProductResponseDto?> GetProductByIdAsync(int id);
        Task<ProductResponseDto> CreateProductAsync(ProductRequestDto productDto);
        Task<bool> UpdateProductAsync(int id, ProductRequestDto productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
