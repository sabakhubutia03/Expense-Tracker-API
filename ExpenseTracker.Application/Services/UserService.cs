using AutoMapper;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entity;
using ExpenseTracker.Domain.Exceptions;
using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Application.Services;

public class UserService :IUserService
{
    public readonly ApplicationDbContext  _context;
    public required IMapper _mapper;
    public readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger, ApplicationDbContext context, IMapper mapper)
    {
        _logger = logger;
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsers()
    {
       var getAllUsers = await _context.Users.ToListAsync();
       return _mapper.Map<IEnumerable<UserDto>>(getAllUsers);
    }

    public async Task<UserDto> CreateUser(UserCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Email))
        {
            _logger.LogError("Email is required");
            throw new ApiException(
                "Email is required",
                "BadRequest",
                400,
                "Email is required",
                "/api/Users/CreateUser"
                );
        }

        if (string.IsNullOrWhiteSpace(dto.Password))
        {
            _logger.LogError("Password is required");
            throw new ApiException(
                "Password is required",
                "BadRequest",
                400,
                "Password is required",
                "/api/Users/CreateUser"
            );
        }

        var existingUser = await _context.Users.FirstOrDefaultAsync(e => e.Email == dto.Email);
        if (existingUser != null)
        {
            _logger.LogError("Email is already registered");
            throw new ApiException(
                "Email is already registered",
                "Conflict",
                409,
                "Email is already registered",
                "/api/Users/CreateUser"
            );
        }
        
        var user = _mapper.Map<User>(dto);
        
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateUser(int id, UserCreateDto dto)
    {
        var userUpdate = await _context.Users.FindAsync(id);
        if (userUpdate == null)
        {
            _logger.LogError("User not found id - {id}", id);
            throw new ApiException(
                $"User not found id - {id}",
                "NotFound",
                404,
                "User not found",
                "/api/Users/UpdateUser"
            );
        }
       if(!string.IsNullOrWhiteSpace(dto.Name)) 
           userUpdate.Name = dto.Name;
       
        if(!string.IsNullOrWhiteSpace(dto.Email))
            userUpdate.Email = dto.Email;
        
        if(!string.IsNullOrWhiteSpace(dto.Password))
            userUpdate.Password = dto.Password;
        
        await _context.SaveChangesAsync();

        return _mapper.Map<UserDto>(userUpdate);
    }

    public async Task<bool> DeleteUser(int id)
    {
        var deleteUser = await _context.Users.FindAsync(id);
        if (deleteUser == null)
        {
            _logger.LogError("User not found id - {id}", id);
            return false;
        }
        _context.Users.Remove(deleteUser);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<UserDto?> GetUserById(int id)
    {
        var getUserById = await _context.Users.FindAsync(id);
        if (getUserById == null)
        {
            _logger.LogWarning("User not found id - {id}", id);
            throw new ApiException(
                $"User not found id - {id}",
                "NotFound",
                404,
                "User not found",
                "/api/Users/GetUserById"
            );
        }
        return _mapper.Map<UserDto>(getUserById);
    }
}