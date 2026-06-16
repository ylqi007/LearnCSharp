using LoggingDemo.Models;
using LoggingDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoggingDemo.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(
        IUserService userService,
        ILogger<UsersController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        _logger.LogInformation("GET /api/users called.");

        List<User> users = _userService.GetAll();

        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetUserById(int id)
    {
        _logger.LogInformation(
            "GET /api/users/{UserId} called.",
            id);

        User? user = _userService.GetById(id);

        if (user is null)
        {
            _logger.LogWarning(
                "Returning 404 for missing user. UserId = {UserId}",
                id);

            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        _logger.LogInformation(
            "POST /api/users called. UserId = {UserId}, Email = {Email}",
            user.Id,
            user.Email);

        User createdUser = _userService.Add(user);

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = createdUser.Id },
            createdUser);
    }
}
