using System.Security.Cryptography.X509Certificates;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
{
    public void Configure(EntityTypeBuilder<Salary> builder)
    {
        builder.ToTable("salary");

        builder.Property(x => x.Emp_Salary)
                .HasColumnType("int")
                .HasMaxLength(11);

        builder.HasKey(x => x.From_DateId);

        builder.HasOne(x => x.Employee)
                .WithMany(x => x.Salaries)
                .HasForeignKey(x => x.Emp_NoId);
        

       
    }
}