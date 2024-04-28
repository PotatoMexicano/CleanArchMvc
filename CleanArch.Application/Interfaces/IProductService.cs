using CleanArch.Application.DTOs;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetById(int id);
        Task<ProductDTO> GetProductCategory(int id);
        Task Add(ProductDTO request);
        Task Update(ProductDTO request);
        Task Remove(int id);
    }
}
