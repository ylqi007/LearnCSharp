using ApiVersioningDemo.Contracts.V2;
using ApiVersioningDemo.Models;
using ApiVersioningDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningDemo.Controllers.V2;

[ApiController]
[Route("api/v2/users")]
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
    public IActionResult GetUsers([FromQuery] bool includeInactive = false)
    {
        _logger.LogInformation(
            "V2 GetUsers called. IncludeInactive = {IncludeInactive}",
            includeInactive);

        IEnumerable<User> query = _userStore.GetAll();

        if (!includeInactive)
        {
            query = query.Where(user => user.IsActive);
        }

        return Ok(query.Select(ToResponse).ToList());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetUserById(int id)
    {
        User? user = _userStore.GetById(id);

        if (user is null)
        {
            return NotFound();
        }

        return Ok(ToResponse(user));
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        int nextId = _userStore.GetAll().Max(user => user.Id) + 1;

        User user = new()
        {
            Id = nextId,
            Name = request.DisplayName,
            Email = request.Email,
            IsActive = true
        };

        User createdUser = _userStore.Add(user);

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = createdUser.Id },
            ToResponse(createdUser));
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeactivateUser(int id)
    {
        bool deactivated = _userStore.Deactivate(id);

        if (!deactivated)
        {
            return NotFound();
        }

        return NoContent();
    }

    private static UserResponse ToResponse(User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            DisplayName = user.Name,
            Email = user.Email,
            IsActive = user.IsActive
        };
    }
}
