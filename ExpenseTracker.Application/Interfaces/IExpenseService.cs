using ExpenseTracker.Application.DTOs;

namespace ExpenseTracker.Application.Interfaces;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseDto>> GetAllExpenses();
    Task<ExpenseDto> CreateExpense(CreateExpenseDto dto);
    Task<ExpenseDto> UpdateExpense(int id, UpdateExpenseDto dto);
    Task<ExpenseDto> GetExpenseById(int id);
    Task<bool> DeleteExpense(int id);
}