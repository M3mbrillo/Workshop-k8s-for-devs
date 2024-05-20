namespace MoonlyBird.Poll.Api.Controllers;

using Microsoft.AspNetCore.Mvc;

public class HealthzController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }
}