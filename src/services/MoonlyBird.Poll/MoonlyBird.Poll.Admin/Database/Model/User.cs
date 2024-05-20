using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MoonlyBird.Poll.Admin.Database.Model
{
    public partial class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual IList<Vote> Votes { get; set; }

    }
    
    namespace ConfigModel
    {
        public class UserConfig : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasKey(u => u.Id);
            
                builder.Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                builder.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(100); 

                builder.HasIndex(x => x.Name)
                    .HasDatabaseName("UX_User_Name")
                    .IsUnique();
                
                builder.HasMany(u => u.Votes)
                    .WithOne(v => v.User)
                    .HasForeignKey(v => v.UserId)
                    .IsRequired();
                
                builder.HasIndex(u => u.Name)
                    .IsUnique();
            }
        }

    }
}