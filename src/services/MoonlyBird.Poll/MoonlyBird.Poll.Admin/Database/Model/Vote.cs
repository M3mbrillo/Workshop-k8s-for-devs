using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoonlyBird.Poll.Admin.Database.Model
{
    public partial class Vote
    {
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public virtual Option Option { get; set; }
        public Guid OptionId { get; set; }
        public Guid PollId { get; set; }

    }

    namespace ConfigModel
    {
        public class VoteConfig : IEntityTypeConfiguration<Vote>
        {
            public void Configure(EntityTypeBuilder<Vote> builder)
            {
                builder.HasKey(model => new
                {
                    model.UserId,
                    model.PollId
                });
                
                builder.HasOne(model => model.User)
                    .WithMany(foreign => foreign.Votes)
                    .HasForeignKey(model => model.UserId)
                    .IsRequired();
                
                builder.HasOne(model => model.Option)
                    .WithMany(foreign => foreign.Votes)
                    .HasForeignKey(model => new { model.OptionId, model.PollId })
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            }
        }
    }
}
