using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker_API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    public readonly IUserService  _userService;
    public readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser(UserCreateDto userDto)
    {
        var createdUser = await _userService.CreateUser(userDto);
        _logger.LogInformation("User created");
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        var users = await _userService.GetAllUsers();
        _logger.LogInformation("Retrieved all users");
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
        var getUserById = await _userService.GetUserById(id);
        _logger.LogInformation("Retrieved user with id {id}", id);
        return Ok(getUserById);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateUser(int id,UserCreateDto dto)
    {
        var updateUser = await _userService.UpdateUser(id,dto);
        _logger.LogInformation("Updating user with id {id}", id);
        return Ok(updateUser);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var delete = await _userService.DeleteUser(id);
        _logger.LogInformation("User deleted");
        return NoContent();
    }

}