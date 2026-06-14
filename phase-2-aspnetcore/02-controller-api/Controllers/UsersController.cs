using ControllerApi.Models;
using ControllerApi.Services;
using Microsoft.AspNetCore.Mvc;     // Controller API 基本都需要它

namespace ControllerApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    // Constructor Injection 
    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    // IActionResult: 这个方法会返回一个 HTTP response
    [HttpGet]
    public IActionResult GetUsers()
    {
        List<User> users = _userService.GetAll();

        return Ok(users);
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
    public IActionResult CreateUser(User user)
    {
        User createdUser = _userService.Add(user);

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = createdUser.Id },
            createdUser);
    }
}
