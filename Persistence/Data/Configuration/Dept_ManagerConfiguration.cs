using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class Dept_ManagerConfiguration : IEntityTypeConfiguration<Dept_Manager>
{
    public void Configure(EntityTypeBuilder<Dept_Manager> builder)
    {
        builder.ToTable("detp_manager");

    


    }
}