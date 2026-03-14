using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entity;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Application.Services;

public class UserService :IUserService
{
    public readonly ApplicationDbContext  _context;
    public readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
        => await _context.Users.ToListAsync();

    public async Task<User> CreateUser(User user)
    {
        if (user == null)
        {
            _logger.LogError("User is null");
        }
        
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public Task<User> UpdateUser(int id, User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserById(int id)
    {
        throw new NotImplementedException();
    }
}