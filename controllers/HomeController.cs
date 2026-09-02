using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ConfigController : ControllerBase
{
    private readonly IConfiguration _config;

    public ConfigController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet("title")]
    public IActionResult GetSiteTitle()
    {
        // Read string from appsettings.json using section path
        string? siteTitle = _config["AppSettings:SiteTitle"];
        return Ok(new { title = siteTitle });
    }
}