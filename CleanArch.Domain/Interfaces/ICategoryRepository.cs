using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetByIdAsync(int id);

        Task<Category> InsertAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> DeleteAsync(Category category);
    }
}
