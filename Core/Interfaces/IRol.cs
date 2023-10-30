using Core.Interfaces;

namespace Core.Entities;

public interface  IRol :IRepositoryGeneric<Role>
{
    Task<Role> GetById(int Id); 
}
