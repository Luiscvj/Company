using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User> 
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasIndex(x => x.Email);
        builder.HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<UserRoles>();
        
                
    }
}