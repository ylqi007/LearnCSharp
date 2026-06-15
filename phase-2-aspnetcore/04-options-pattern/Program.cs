using OptionsPatternDemo.Options;
using OptionsPatternDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// 从配置系统中读取 UserSettings section
// 把它绑定到 UserSettingsOptions class
// 并注册到 DI container
// 之后其他 class 可以通过 IOptions<UserSettingsOptions> 注入它
builder.Services.Configure<UserSettingsOptions>(
    builder.Configuration.GetSection(UserSettingsOptions.SectionName));

builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.MapGet("/", () => "Hello Options Pattern");

app.MapControllers();

app.Run();
