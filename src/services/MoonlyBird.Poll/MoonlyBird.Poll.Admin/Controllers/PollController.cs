using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoonlyBird.Poll.Admin.Database;
using MoonlyBird.Poll.Admin.Database.Model;
using MoonlyBird.Poll.Admin.Model;

namespace MoonlyBird.Poll.Admin.Controllers;


[Route("poll")]
[ApiController]
public class PollController : Controller
{
    private readonly DbMoonlyBirdPollContext _dbContext;

    public PollController(DbMoonlyBirdPollContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var result = from v in _dbContext.Polls.AsQueryable()
                     select new PollDto(
                         v.Id,
                         v.Name,
                         v.Options.ToList().Select(option =>
                             new OptionDto(
                                 option.Id,
                                 option.Name,
                                 option.Votes.Count()
                                 )
                         ).ToArray());
        
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public IActionResult Index(Guid id)
    {
        var result = from v in _dbContext.Polls.AsQueryable()
            where v.Id == id
            select new PollDto(
                v.Id,
                v.Name,
                v.Options.Select(option =>
                    new OptionDto(
                        option.Id,
                        option.Name,
                        option.Votes.Count()
                    )
                ).ToArray());

        var poll = result.FirstOrDefault();

        return poll is not null ?
            Ok(poll) :
            NotFound();
    }

    [HttpPost]
    public IActionResult Create([FromBody]PollDto pollDto)
    {
        var poll = new Database.Model.Poll()
        {
            Id = pollDto.Id ?? Guid.NewGuid(),
            Name = pollDto.Name
        };

        _dbContext.Polls.Add(poll);

        foreach (var option in pollDto.options)
        {
            poll.Options.Add(new Option()
            {
                Id = option.Id ?? Guid.NewGuid(),
                Name = option.Name
            });
        }
        _dbContext.SaveChanges();
        
        return Created();
    }
}