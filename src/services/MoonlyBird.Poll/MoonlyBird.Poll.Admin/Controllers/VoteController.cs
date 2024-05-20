using Microsoft.AspNetCore.Mvc;
using MoonlyBird.Poll.Admin.Database;
using MoonlyBird.Poll.Admin.Model;

namespace MoonlyBird.Poll.Admin.Controllers;

[Route("vote")]
[ApiController]
public class VoteController : Controller
{
    private readonly DbMoonlyBirdPollContext _dbContext;

    public VoteController(Database.DbMoonlyBirdPollContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpPost]
    public IActionResult AddVote([FromBody] VoteDto voteDto)
    {
        var vote = new Database.Model.Vote()
        {
            OptionId = voteDto.OptionId,
            PollId = voteDto.PollId,
            UserId = voteDto.UserId
        };

        _dbContext.Votes.Add(vote);

        _dbContext.SaveChanges();
        
        return Ok();
    }
}