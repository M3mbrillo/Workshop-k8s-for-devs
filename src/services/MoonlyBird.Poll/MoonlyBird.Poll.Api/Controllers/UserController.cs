using Microsoft.AspNetCore.Mvc;
using MoonlyBird.Poll.Api.Model;
using MoonlyBird.Poll.Api.Util;

namespace MoonlyBird.Poll.Api.Controllers;

[Route("user/{userId}")]
[ApiController]
public class UserController : Controller
{
    private readonly PollAdminClient _pollAdminClient;

    public UserController(Util.PollAdminClient pollAdminClient)
    {
        _pollAdminClient = pollAdminClient;
    }

    [HttpPost("vote")]
    public async Task<IActionResult> Vote([FromBody] VoteDto vote, [FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var response = await _pollAdminClient.Vote(vote.PollId, vote.OptionId, userId, cancellationToken);

        return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync(cancellationToken));
    }
    
    
    [HttpGet("polls")]
    public async Task<IActionResult> Polls(CancellationToken cancellationToken)
    {
        var response = await _pollAdminClient.GetPolls(cancellationToken);

        return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync(cancellationToken));
    }
    
}