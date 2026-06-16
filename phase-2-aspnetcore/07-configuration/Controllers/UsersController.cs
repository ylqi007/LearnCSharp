using ConfigurationDemo.Models;
using ConfigurationDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationDemo.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("paged")]
    public IActionResult GetPagedUsers()
    {
        return Ok(_userService.GetPagedUsers());
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        User? createdUser = _userService.Add(
            request.Name,
            request.Email);

        if (createdUser is null)
        {
            return BadRequest("User creation is disabled by configuration.");
        }

        return Created(string.Empty, createdUser);
    }
}

public class CreateUserRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Email { get; set; }
}
