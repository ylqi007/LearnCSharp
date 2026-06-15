using Microsoft.AspNetCore.Mvc;
using OptionsPatternDemo.Models;
using OptionsPatternDemo.Services;

namespace OptionsPatternDemo.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_userService.GetAll());
    }

    [HttpGet("paged")]
    public IActionResult GetPagedUsers()
    {
        return Ok(_userService.GetPagedUsers());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetUserById(int id)
    {
        User? user = _userService.GetById(id);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
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

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = createdUser.Id },
            createdUser);
    }
}

public class CreateUserRequest
{
    public string Name { get; set; } = string.Empty;

    public string? Email { get; set; }
}
