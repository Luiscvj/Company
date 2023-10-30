using Core.Interfaces;

namespace Core.Entities;


public interface IGenericDeptManager_DeptEmp<T> : IRepositoryGeneric<T> where T: class
{
    Task<T> GetByDeptId_EmpId(char Dept_noId,int Emp_NoId);
}