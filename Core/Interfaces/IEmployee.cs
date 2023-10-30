using Core.Entities;

namespace Core.Interfaces;

public interface IEmployee : IRepositoryGeneric<Employee>
{
    Task<Employee> GetById(int Id);
}