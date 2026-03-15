using AutoMapper;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entity;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Application.Services;

public class ExpenseService : IExpenseService
{
    public readonly ApplicationDbContext _context;
    public readonly IMapper _mapper;
    public readonly ILogger<ExpenseService> _logger;

    public ExpenseService(ApplicationDbContext context, IMapper mapper, ILogger<ExpenseService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<IEnumerable<ExpenseDto>> GetAllExpenses()
    {
        var getAllExpense = await _context.Expenses.ToListAsync();
        return _mapper.Map<IEnumerable<ExpenseDto>>(getAllExpense);
    }

    public async Task<ExpenseDto> CreateExpense(CreateExpenseDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title))
        {
            _logger.LogError(" Is null expense name");
            throw new ArgumentException("Is null expense name");
        }

        if (dto.Amount <= 0)
        {
            _logger.LogError(" Is not a valid expense amount");
            throw new ArgumentException("Is not a valid expense amount");
        }

        var expense = _mapper.Map<Expense>(dto);
        
        await _context.Expenses.AddAsync(expense);
        await _context.SaveChangesAsync();
        return _mapper.Map<ExpenseDto>(expense);

    }

    public async Task<ExpenseDto> UpdateExpense(int id, UpdateExpenseDto dto)
    {
        var updateExpense = await _context.Expenses.FindAsync(id);
        if (updateExpense == null)
        {
            _logger.LogError(" Is not found expense id -{id}", id);
            throw new ArgumentException("Is not found expense");
        }
        
        if(!string.IsNullOrWhiteSpace(dto.Title))
            updateExpense.Title = dto.Title;
        if(dto.Amount > 0)
            updateExpense.Amount = dto.Amount;
        if(dto.Date != default(DateTime))
            updateExpense.Date = dto.Date;

        await _context.SaveChangesAsync();
        return _mapper.Map<ExpenseDto>(updateExpense);
    }

    public async Task<ExpenseDto> GetExpenseById(int id)
    {
        var getExpenseById = await _context.Expenses.FindAsync(id);
        if (getExpenseById == null)
        {
            _logger.LogError(" Is not found expense id - {id}", id);
        }
        return _mapper.Map<ExpenseDto>(getExpenseById);
    }

    public async Task<bool> DeleteExpense(int id)
    {
        var deleteExpense = await _context.Expenses.FindAsync(id);
        if (deleteExpense == null)
        {
            _logger.LogWarning("Is not found expense id {id}", id);
            return false;
        }

        _context.Expenses.Remove(deleteExpense);
        await _context.SaveChangesAsync();
        return true;
    }
}