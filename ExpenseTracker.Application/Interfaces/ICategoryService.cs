using ExpenseTracker.Application.DTOs;

namespace ExpenseTracker.Application.Interfaces;

public interface ICategoryService
{
    Task<CategoryDto> CreateCategory(CreateCategoryDto dto);
    Task<IEnumerable<CategoryDto>> GetAllCategories();
    Task<CategoryDto?> GetCategoryById(int id);
    Task<CategoryDto> UpdateCategory(int id,UpdateCategory dto);
    Task<bool> DeleteCategory(int id);
}