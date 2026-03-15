using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Domain.Entity;

namespace ExpenseTracker.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsers();
    Task<UserDto> CreateUser(UserCreateDto dto);
    Task<UserDto> UpdateUser(int id,UserCreateDto dto);
    Task<bool> DeleteUser(int id);
    Task<UserDto?> GetUserById(int id);
}