using AsyncAwait.Models;

namespace AsyncAwait.Services;

public class UserService
{
    public async Task<User> GetUserAsync(string userId)
    {
        await Task.Delay(300);
        return new User { Id = userId, Name = "Alex", Department = "Azure Identity" };
    }

    public async Task<List<User>> GetUsersAsync()
    {
        await Task.Delay(500);
        return
        [
            new User { Id = "u001", Name = "Alex", Department = "Azure Identity" },
            new User { Id = "u002", Name = "Taylor", Department = "Security" },
            new User { Id = "u003", Name = "Morgan", Department = "Platform" }
        ];
    }

    public async Task<User> GetManagerAsync(User user)
    {
        await Task.Delay(300);
        return new User
        {
            Id = $"manager-of-{user.Id}",
            Name = "Manager",
            Department = user.Department
        };
    }
}
