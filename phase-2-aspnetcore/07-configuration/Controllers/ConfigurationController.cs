using ConfigurationDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationDemo.Controllers;

[ApiController]
[Route("api/configuration")]
public class ConfigurationController : ControllerBase
{
    private readonly IConfigurationReporter _configurationReporter;

    public ConfigurationController(
        IConfigurationReporter configurationReporter)
    {
        _configurationReporter = configurationReporter;
    }

    [HttpGet]
    public IActionResult GetConfigurationReport()
    {
        return Ok(_configurationReporter.GetReport());
    }
}
