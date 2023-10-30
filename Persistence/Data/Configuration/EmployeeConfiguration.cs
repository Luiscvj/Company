using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Persistence.Data.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("employee");

        builder.Property(x => x.First_Name)
                .HasMaxLength(14);
        builder.Property(x => x.Last_Name)
                .HasMaxLength(16);
        builder.HasKey(x => x.Emp_NoId);
    }
}