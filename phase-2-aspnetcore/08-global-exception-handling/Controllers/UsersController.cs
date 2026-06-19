using GlobalExceptionDemo.Contracts;
using GlobalExceptionDemo.Models;
using GlobalExceptionDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionDemo.Controllers;

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

    [HttpGet("{id:int}")]
    public IActionResult GetUserById(int id)
    {
        return Ok(_userService.GetById(id));
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        User user = new()
        {
            Id = Random.Shared.Next(100, 999),
            Name = request.Name,
            Email = request.Email
        };

        User createdUser = _userService.Create(user);

        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }

    [HttpPost("with-id/{id:int}")]
    public IActionResult CreateUserWithId(int id, CreateUserRequest request)
    {
        User user = new()
        {
            Id = id,
            Name = request.Name,
            Email = request.Email
        };

        User createdUser = _userService.Create(user);

        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }

    [HttpGet("simulate-failure")]
    public IActionResult SimulateFailure()
    {
        _userService.SimulateFailure();
        return Ok();
    }
}
