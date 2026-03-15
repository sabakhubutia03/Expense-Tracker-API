using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker_API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{
    public readonly IExpenseService  _expenseService;
    public readonly ILogger<ExpenseController> _logger;

    public ExpenseController(IExpenseService expenseService, ILogger<ExpenseController> logger)
    {
        _expenseService = expenseService;
        _logger = logger;
    }
    [HttpPost]
    public async Task<ActionResult<ExpenseDto>> CreateExpense(CreateExpenseDto dto)
    {
        var createExpense = await _expenseService.CreateExpense(dto);
        _logger.LogInformation("Create expense");
        return CreatedAtAction(nameof(GetExpenseById), new { id = createExpense.Id }, createExpense);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetAllExpenses()
    {
        var getExpenses = await _expenseService.GetAllExpenses();
        _logger.LogInformation("Get expenses");
        return Ok(getExpenses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExpenseDto>> GetExpenseById(int id)
    {
        var getExpenseById = await _expenseService.GetExpenseById(id);
        _logger.LogInformation("Get expense by id - {id}",id);
        return Ok(getExpenseById);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ExpenseDto>> UpdateExpense(int id, UpdateExpenseDto dto)
    {
        var updateExpense = await _expenseService.UpdateExpense(id, dto);
        _logger.LogInformation("Update expense");
        return Ok(updateExpense);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteExpense(int id)
    {
        var deleteExpense = await _expenseService.DeleteExpense(id);
        _logger.LogInformation("Delete expense");
        return NoContent();
    }
}