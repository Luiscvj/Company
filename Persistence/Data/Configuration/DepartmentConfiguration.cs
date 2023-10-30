using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Departament>
{
    public  void Configure(EntityTypeBuilder<Departament> builder)
    {
        builder.ToTable("department");

        builder.Property(x => x.Dept_NoId)
        .HasColumnType("char")
        .HasMaxLength(4);

        builder.Property(x => x.Dept_Name)
        .HasMaxLength(50);

        builder.HasKey(x => x.Dept_NoId);

        builder.HasMany(x => x.Employees)
                .WithMany(x => x.Departaments)
                .UsingEntity<Dept_Manager>();

        builder.HasMany(x => x.Employees)
                .WithMany(x => x.Departaments)
                .UsingEntity<Dept_Emp>();
    }
}