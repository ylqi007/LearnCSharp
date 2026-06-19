using ApiVersioningDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IUserStore, InMemoryUserStore>();

var app = builder.Build();

app.MapGet("/", () => "Hello API Versioning");

app.MapControllers();

app.Run();
