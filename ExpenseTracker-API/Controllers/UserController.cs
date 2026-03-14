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
    public async Task<ActionResult> CreateUser(User user)
    {
        var createdUser = await _userService.CreateUser(user);
        _logger.LogInformation("User created");
        return Ok(createdUser);
    }

    [HttpGet]
    public async Task<ActionResult<User>> GetUser()
    {
        var getUser = await _userService.GetAllUsers();
        _logger.LogInformation("Get all users");
        return Ok(getUser);
    }
}