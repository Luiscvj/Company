using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class Dept_ManagerRepository : RepositoryGeneric<Dept_Manager> , IGenericDeptManager_DeptEmp<Dept_Manager>,IDept_Manager
{
    public Dept_ManagerRepository(CompanyContext context) : base(context)
    {

    }

    public async Task<Dept_Manager> GetByDeptId_EmpId(char Dept_noId, int Emp_NoId)
    {
      return   await _Context.Set<Dept_Manager>().FirstOrDefaultAsync(x => x.EmployeeId == Emp_NoId && x.DepartmentId == Dept_noId);
    }


}