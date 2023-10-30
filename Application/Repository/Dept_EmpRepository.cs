using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class Dept_EmpRepository : RepositoryGeneric<Dept_Emp>, IGenericDeptManager_DeptEmp<Dept_Emp>, IDept_Emp
{

    public Dept_EmpRepository(CompanyContext context) : base(context)
    {

    }
    public async Task<Dept_Emp> GetByDeptId_EmpId(char Dept_noId, int Emp_NoId)
    {
       return await _Context.Set<Dept_Emp>().FirstOrDefaultAsync(x => x.EmployeeId == Emp_NoId && x.DepartamentId == Dept_noId); 
    }
}