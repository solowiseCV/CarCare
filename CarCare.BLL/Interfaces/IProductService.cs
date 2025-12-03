using CarCare.DTOs.Product.RequestDto;
using CarCare.DTOs.Product.ResponseDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCare.BLL.Interfaces 
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
