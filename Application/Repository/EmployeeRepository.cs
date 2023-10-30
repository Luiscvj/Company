using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class EmployeeRepository : RepositoryGeneric<Employee>, IEmployee
{

    public EmployeeRepository(CompanyContext context) : base(context)
    {

    }
    public async  Task<Employee> GetById(int Id)
    {
        return await _Context.Set<Employee>().FirstOrDefaultAsync(x => x.Emp_NoId == Id);
    }
}