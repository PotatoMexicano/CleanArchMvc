using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _repository = productRepository;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO request)
        {
            var productEntity = _mapper.Map<Product>(request);
            await _repository.InsertAsync(productEntity);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int id)
        {
            var productEntity = await _repository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            IEnumerable<Product> productsEntity = await _repository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task Remove(int id)
        {
            var productEntity = _repository.GetByIdAsync(id).Result;
            await _repository.DeleteAsync(productEntity);
        }

        public async Task Update(ProductDTO request)
        {
            var productEntity = _mapper.Map<Product>(request);
            await _repository.UpdateAsync(productEntity);
        }
    }
}
