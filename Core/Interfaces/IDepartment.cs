using Core.Interfaces;

namespace Core.Entities;


public interface IDepartment : IRepositoryGeneric<Departament>
{
    Task<Departament> GetById(int Id); 
}