using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class DepartamentRepository : RepositoryGeneric<Departament> , IDepartment
{
    public DepartamentRepository(CompanyContext context) : base(context)
    {
        
    }

    public async  Task<Departament> GetById(int Id)
    {
       return await  _Context.Set<Departament>().FirstOrDefaultAsync(x => x.Dept_NoId == Id);
    }
}


