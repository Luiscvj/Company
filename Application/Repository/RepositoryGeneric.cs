using System.Linq.Expressions;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
{
    protected readonly CompanyContext _Context;

    public RepositoryGeneric(CompanyContext context)
    {
        _Context = context;
    }
    public virtual  void Add(T entity)
    {
        _Context.Set<T>().Add(entity);
    }

    public virtual  void AddRange(IEnumerable<T> entities)
    {
        _Context.Set<T>().AddRange(entities);
    }

    public virtual    IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
       return  _Context.Set<T>().Where(expression);
    }

    public virtual  async Task<IEnumerable<T>> GetAll()
    {
        return await _Context.Set<T>().ToListAsync();
    }

    public virtual  void Remove(T entity)
    {
        _Context.Set<T>().Remove(entity);
    }

    public virtual  void RemoveRange(IEnumerable<T> Entities)
    {
        _Context.Set<T>().RemoveRange(Entities);
    }

    public virtual  void Update(T entity)
    {
        _Context.Set<T>().Update(entity);
    }
}