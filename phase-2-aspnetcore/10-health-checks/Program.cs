using HealthChecksDemo.HealthChecks;
using HealthChecksDemo.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<DemoDependencyOptions>(
    builder.Configuration.GetSection(DemoDependencyOptions.SectionName));

builder.Services.AddSingleton<IDemoDependencyStatus, DemoDependencyStatus>();

builder.Services
    .AddHealthChecks()
    .AddCheck<SelfHealthCheck>(
        "self",
        tags: ["live"])
    .AddCheck<DatabaseHealthCheck>(
        "database",
        failureStatus: HealthStatus.Unhealthy,
        tags: ["ready"])
    .AddCheck<ExternalApiHealthCheck>(
        "external-api",
        failureStatus: HealthStatus.Degraded,
        tags: ["ready"]);

var app = builder.Build();

app.MapGet("/", () => "Hello Health Checks");

app.MapControllers();

app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("live"),
    ResponseWriter = WriteHealthResponseAsync
});

app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = check => check.Tags.Contains("ready"),
    ResponseWriter = WriteHealthResponseAsync
});

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = WriteHealthResponseAsync
});

app.Run();

static Task WriteHealthResponseAsync(
    HttpContext context,
    HealthReport report)
{
    context.Response.ContentType = "application/json";

    var response = new
    {
        status = report.Status.ToString(),
        totalDurationMs = report.TotalDuration.TotalMilliseconds,
        checks = report.Entries.Select(entry => new
        {
            name = entry.Key,
            status = entry.Value.Status.ToString(),
            description = entry.Value.Description,
            durationMs = entry.Value.Duration.TotalMilliseconds,
            data = entry.Value.Data
        })
    };

    string json = JsonSerializer.Serialize(
        response,
        new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        });

    return context.Response.WriteAsync(json);
}
