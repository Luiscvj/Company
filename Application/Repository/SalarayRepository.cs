using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class SalaryRepository : RepositoryGeneric<Salary>, ISalary
{
    public SalaryRepository(CompanyContext context) : base(context)
    {
    }

    public async  Task<Salary> GetByTitle_Date( DateTime From_Date)
    {
        return await _Context.Set<Salary>().FirstOrDefaultAsync(x => x.From_DateId == From_Date);
    }
}