using System.Linq.Expressions;

namespace Core.Interfaces;

public interface IRepositoryGeneric<T> where T: class
{
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
 
    Task<IEnumerable<T>> GetAll();
    IEnumerable<T> Find(Expression<Func<T,bool>> expression);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> Entities);
    void Update(T entity);
}