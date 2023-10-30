using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class TitleConfiguration : IEntityTypeConfiguration<Title>
{
    public void Configure(EntityTypeBuilder<Title> builder)
    {
        builder.ToTable("title");
      
        builder.HasKey(dm => new{ dm.Title_Id,dm.From_Date});

        builder.HasOne(x => x.Employee)
                .WithMany(x => x.Titles)
                .HasForeignKey(x => x.Emp_NoId);
    }
    
}