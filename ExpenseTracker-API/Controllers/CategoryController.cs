using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker_API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    public readonly ICategoryService _categoryService;
    public readonly ILogger<CategoryController> _logger;

    public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
    {
        _categoryService = categoryService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
    {
        var getCategories = await _categoryService.GetAllCategories();
        _logger.LogInformation("Get all Categories");
        return Ok(getCategories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetCategory(int id)
    {
        var getCategoryById = await _categoryService.GetCategoryById(id);
        _logger.LogInformation("Get Category by id");
        return Ok(getCategoryById);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDto>> CreateExpense(CreateCategoryDto dto)
    {
        var createCategory = await _categoryService.CreateCategory(dto);
        _logger.LogInformation("Create Category");
        return CreatedAtAction(nameof(GetCategory), new { id = createCategory.Id }, createCategory);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryDto>> UpdateExpense(int id, UpdateCategory dto)
    {
        var updateCategory = await _categoryService.UpdateCategory(id, dto);
        _logger.LogInformation("Update Category");
        return Ok(updateCategory);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteExpense(int id)
    {
        var deleteCategory = await _categoryService.DeleteCategory(id);
        _logger.LogInformation("Delete Category");
        return NoContent();
    }
    
}