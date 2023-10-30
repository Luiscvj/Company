using Core.Entities;

namespace Core.Interfaces;

public interface IUnitOfWork
{
    IDepartment Departments {get;}
    IDept_Emp Dept_Emps {get;}
    IDept_Manager Dept_Managers {get;}
    IEmployee Employees {get;}
    IRol Roles {get;}
    ISalary Salaries {get;}
    ITitle Titles {get;}
    IUser Users {get;}
    Task<int> SaveAsync();

}