using ExpenseTracker.Domain.Entity;

namespace ExpenseTracker.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(int id,User user);
    Task<bool> DeleteUser(int id);
    Task<User?> GetUserById(int id);
}