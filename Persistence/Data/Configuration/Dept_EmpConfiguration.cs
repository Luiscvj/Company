using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class Dept_EmpConfiguration : IEntityTypeConfiguration<Dept_Emp>
{
    public void Configure(EntityTypeBuilder<Dept_Emp> builder)
    {
        builder.ToTable("dept_emp");
    }
}