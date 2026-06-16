using ConfigurationDemo.Options;
using ConfigurationDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<ApplicationOptions>(
    builder.Configuration.GetSection(ApplicationOptions.SectionName));

builder.Services.Configure<UserSettingsOptions>(
    builder.Configuration.GetSection(UserSettingsOptions.SectionName));

builder.Services.Configure<ExternalServicesOptions>(
    builder.Configuration.GetSection(ExternalServicesOptions.SectionName));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IConfigurationReporter, ConfigurationReporter>();

var app = builder.Build();

Console.WriteLine(
    $"Environment = {builder.Environment.EnvironmentName}");

app.MapGet("/", (IConfiguration configuration, IWebHostEnvironment environment) =>
{
    return Results.Ok(new
    {
        Message = "Hello Configuration",
        Environment = environment.EnvironmentName,
        ApplicationName = configuration["Application:Name"],
        ApplicationVersion = configuration["Application:Version"],
        EnvironmentLabel = configuration["Application:EnvironmentLabel"]
    });
});

app.MapGet("/debug-env",
    (IConfiguration config,
     IWebHostEnvironment env) =>
{
    return Results.Ok(new
    {
        EnvironmentName = env.EnvironmentName,

        AspNetCoreEnvironment =
            Environment.GetEnvironmentVariable(
                "ASPNETCORE_ENVIRONMENT"),

        DotNetEnvironment =
            Environment.GetEnvironmentVariable(
                "DOTNET_ENVIRONMENT")
    });
});

app.MapControllers();

app.Run();
