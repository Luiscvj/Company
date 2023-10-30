using Core.Interfaces;

namespace Core.Entities;

public interface ISalary :IRepositoryGeneric<Salary>
{
     Task<Salary> GetByTitle_Date( DateTime From_Date);
}