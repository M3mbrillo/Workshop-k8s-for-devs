using Microsoft.AspNetCore.Mvc;
using MoonlyBird.Poll.Admin.Database;

namespace MoonlyBird.Poll.Admin.Controllers;

[Route("Healthz")]
public class HealthzController : Controller
{
    private readonly DbMoonlyBirdPollContext _dbContext;

    public HealthzController(DbMoonlyBirdPollContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var canConnect = await _dbContext.Database.CanConnectAsync(cancellationToken);
        
        return Ok(canConnect);
    }
}