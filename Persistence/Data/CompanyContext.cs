using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;


public class CompanyContext : DbContext
{
    public CompanyContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Departament> Departaments {get;set;}
    public DbSet<Dept_Emp> Dept_Emps {get;set;}
    public DbSet<Dept_Manager> Dept_Managers {get;set;}
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Salary> Salaries { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}