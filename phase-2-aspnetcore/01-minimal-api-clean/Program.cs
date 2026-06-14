using MinimalApi.Models;
using MinimalApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<UserService>();

var app = builder.Build();

app.MapGet("/", () => "Hello Minimal API");

app.MapGet("/users", (UserService service) =>
{
    return Results.Ok(service.GetAll());
});

app.MapPost("/users", (User user, UserService service) =>
{
    service.Add(user);
    return Results.Created($"/users/{user.Id}", user);
});

app.Run();
