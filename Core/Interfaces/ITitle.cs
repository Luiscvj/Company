using Core.Entities;

namespace Core.Interfaces;

public interface ITitle : IRepositoryGeneric<Title>
{
    Task<Title> GetByTtile_Date(string Title,DateTime Date);
}