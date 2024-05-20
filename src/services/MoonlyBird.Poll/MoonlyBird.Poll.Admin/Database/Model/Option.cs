using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoonlyBird.Poll.Admin.Database.Model
{
    public partial class Option
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        public virtual Poll Poll { get; set; }
        public virtual Guid PollId { get; set; }
        public virtual IList<Vote> Votes { get; set; }
    }

    namespace ConfigModel
    {
        public class OptionConfig : IEntityTypeConfiguration<Option>
        {
            public void Configure(EntityTypeBuilder<Option> builder)
            {
                builder.HasKey(model => new { model.Id, model.PollId });

                builder.HasOne<Poll>(model => model.Poll)
                    .WithMany(navigation => navigation.Options);

                builder.HasMany(model => model.Votes)
                    .WithOne(relation => relation.Option)
                    .HasForeignKey(foreign => new { foreign.PollId, foreign.OptionId })
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

            }
        }
    }
}