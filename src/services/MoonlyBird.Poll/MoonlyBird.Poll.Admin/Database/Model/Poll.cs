using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoonlyBird.Poll.Admin.Database.Model
{
    public partial class Poll
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public virtual IList<Option> Options { get; set; } = new List<Option>();
    }
    
    namespace ConfigModel
    {
        public class PollConfig : IEntityTypeConfiguration<Poll>
        {
            public void Configure(EntityTypeBuilder<Poll> builder)
            {
                builder.HasKey(p => p.Id);
            
                builder.Property(p => p.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                builder.HasMany(p => p.Options)
                    .WithOne(v => v.Poll)
                    .HasForeignKey(v => v.PollId)
                    .IsRequired();
                
                builder.HasIndex(p => p.Name)
                    .IsUnique();
            }
        }
    }
}