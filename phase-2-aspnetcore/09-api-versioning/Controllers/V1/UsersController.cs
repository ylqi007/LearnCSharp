using ApiVersioningDemo.Contracts.V1;
using ApiVersioningDemo.Models;
using ApiVersioningDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemo.Controllers.V1;

[ApiController]
[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IUserStore _userStore;
    private readonly ILogger<UsersController> _logger;

    public UsersController(IUserStore userStore, ILogger<UsersController> logger)
    {
        _userStore = userStore;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        _logger.LogInformation("V1 GetUsers called.");

        List<UserResponse> users = _userStore
            .GetAll()
            .Select(user => new UserResponse
            {
                Id = user.Id,
                Name = user.Name
            })
            .ToList();

        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetUserById(int id)
    {
        User? user = _userStore.GetById(id);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(new UserResponse
        {
            Id = user.Id,
            Name = user.Name
        });
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        int nextId = _userStore.GetAll().Max(user => user.Id) + 1;

        User user = new()
        {
            Id = nextId,
            Name = request.Name,
            Email = $"{request.Name.ToLowerInvariant()}@example.com",
            IsActive = true
        };

        User createdUser = _userStore.Add(user);

        UserResponse response = new()
        {
            Id = createdUser.Id,
            Name = createdUser.Name
        };

        return CreatedAtAction(nameof(GetUserById), new { id = response.Id }, response);
    }
}
