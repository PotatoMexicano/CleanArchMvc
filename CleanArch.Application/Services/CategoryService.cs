using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _repository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            IEnumerable<Category> categoriesEntity = await _repository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            Category? categoryEntity = await _repository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Add(CategoryDTO request)
        {
            Category categoryEntity = _mapper.Map<Category>(request);
            await _repository.InsertAsync(categoryEntity);
        }

        public async Task Update(CategoryDTO request)
        {
            Category categoryEntity = _mapper.Map<Category>(request);
            await _repository.UpdateAsync(categoryEntity);
        }

        public async Task Remove(int id)
        {
            Category? categoryEntity = _repository.GetByIdAsync(id).Result;
            await _repository.DeleteAsync(categoryEntity);

        }
    }
}
