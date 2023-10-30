using Core.Entities;

namespace Core.Interfaces;

public interface IUser : IRepositoryGeneric<User>
{
    Task<User> GetById(int Id);

    Task<User> GetByUserName(string userName);
}