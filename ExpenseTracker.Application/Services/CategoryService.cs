using AutoMapper;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entity;
using ExpenseTracker.Domain.Exceptions;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Application.Services;

public class CategoryService : ICategoryService
{ 
    public readonly ApplicationDbContext _context;
    public readonly IMapper _mapper;
    public readonly ILogger<CategoryService> _logger;

    public CategoryService(ApplicationDbContext context, IMapper mapper, ILogger<CategoryService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<CategoryDto> CreateCategory(CreateCategoryDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            _logger.LogError("Name is required");
            throw new ApiException(
                "Name is required",
                "BadRequest",
                400,
                "Name is required",
                "/api/Category/CreateCategory");
        }
        var category = _mapper.Map<Category>(dto);
        
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
    {
        var categoriesGet = await _context.Categories.ToListAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(categoriesGet);
    }

    public async Task<CategoryDto?> GetCategoryById(int id)
    {
        var getCategoryById = await _context.Categories.FindAsync(id);
        if (getCategoryById == null)
        {
            _logger.LogWarning("Category with id {id} was not found", id);
        }
        return _mapper.Map<CategoryDto>(getCategoryById);
    }

    public async Task<CategoryDto> UpdateCategory(int id, UpdateCategory dto)
    {
            
        var updateCategory = await _context.Categories.FindAsync(id);
        if (updateCategory == null)
        {
            _logger.LogWarning("Category with id {id} was not found", id);
            throw new ApiException(
                $"Category with id {id} was not found",
                "NotFound",
                404,
                $"Category with id {id} was not found",
                "/api/Category/UpdateCategory"
            );
        }
        
        if(!string.IsNullOrWhiteSpace(dto.Name)) 
            updateCategory.Name = dto.Name;
        
        await _context.SaveChangesAsync();
        return _mapper.Map<CategoryDto>(updateCategory);
        
    }

    public async Task<bool> DeleteCategory(int id)
    {
        var deleteCategory = await _context.Categories.FindAsync(id);
        if (deleteCategory == null)
        {
            _logger.LogError("Category Id {id}  was not found", id);
            return false;
        }
        
        _context.Categories.Remove(deleteCategory);
        await _context.SaveChangesAsync();
        return true;
        
    }
}