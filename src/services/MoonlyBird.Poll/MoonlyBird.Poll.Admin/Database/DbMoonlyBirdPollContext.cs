using Microsoft.EntityFrameworkCore;

namespace MoonlyBird.Poll.Admin.Database;

public class DbMoonlyBirdPollContext : DbContext
{
    public DbSet<Model.Poll> Polls { get; set; }

    public DbSet<Model.Vote> Votes { get; set; }

    public DbSet<Model.User> Users { get; set; }


    public DbMoonlyBirdPollContext(DbContextOptions<DbMoonlyBirdPollContext> options)
        :base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Model.ConfigModel.UserConfig());
        modelBuilder.ApplyConfiguration(new Model.ConfigModel.PollConfig());
        modelBuilder.ApplyConfiguration(new Model.ConfigModel.OptionConfig());
        modelBuilder.ApplyConfiguration(new Model.ConfigModel.VoteConfig());
    }
}