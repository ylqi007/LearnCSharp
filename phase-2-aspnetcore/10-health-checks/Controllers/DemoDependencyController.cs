using HealthChecksDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthChecksDemo.Controllers;

[ApiController]
[Route("api/demo-dependencies")]
public class DemoDependencyController : ControllerBase
{
    private readonly IDemoDependencyStatus _dependencyStatus;

    public DemoDependencyController(
        IDemoDependencyStatus dependencyStatus)
    {
        _dependencyStatus = dependencyStatus;
    }

    [HttpPost("database/{isAvailable:bool}")]
    public IActionResult SetDatabaseAvailability(bool isAvailable)
    {
        _dependencyStatus.SetDatabaseAvailability(isAvailable);

        return Ok(new
        {
            dependency = "database",
            isAvailable
        });
    }

    [HttpPost("external-api/{isAvailable:bool}")]
    public IActionResult SetExternalApiAvailability(bool isAvailable)
    {
        _dependencyStatus.SetExternalApiAvailability(isAvailable);

        return Ok(new
        {
            dependency = "external-api",
            isAvailable
        });
    }
}
