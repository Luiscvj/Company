using Application.Repository;
using Core.Entities;
using Core.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;


public class UnitOfWork : IUnitOfWork , IDisposable
{


    protected  CompanyContext _Context;

    private  DepartamentRepository _department;
    private  Dept_EmpRepository _dept_Emp;
    private  Dept_ManagerRepository _dept_Manager;
    private  EmployeeRepository _employee;
    private  RolRepository _rol;
    private  SalaryRepository _salary;
    private  TitleRepository _title;
    private  UserRepository _user;

    public UnitOfWork(CompanyContext context)
    {
        _Context = context;
    }


    public IDepartment Departments 
    {
        get
        {
           _department ??= new DepartamentRepository(_Context);//Agrega el valor a _department unicamente si es nulo
           return _department;
        }
    }

    public IDept_Emp Dept_Emps
    {
        get
        {
            _dept_Emp ??= new Dept_EmpRepository(_Context);
            return _dept_Emp;
        }
    }

    public IDept_Manager Dept_Managers
    {
        get
        {
            _dept_Manager ??= new Dept_ManagerRepository(_Context);
            return _dept_Manager;
        }
    } 

    public IEmployee Employees
    {
        get
        {
            _employee ??= new EmployeeRepository(_Context);
            return _employee;
        }
    }

    public IRol Roles 
    {
        get
        {
            _rol ??= new RolRepository(_Context);
            return _rol;
        }
    }

    public ISalary Salaries
    {
        get
        {
            _salary ??= new SalaryRepository(_Context);
            return _salary;
        }
    }


    public ITitle Titles
    {
        get
        {
            _title ??= new TitleRepository(_Context);
            return _title;
        }
    }

    public IUser Users
    {
        get
        {
            _user ??= new UserRepository(_Context);
            return _user;
        }
    }

    public void Dispose()
    {
        _Context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
       return await _Context.SaveChangesAsync();
    }
}