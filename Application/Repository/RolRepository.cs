using System.Runtime.CompilerServices;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class RolRepository : RepositoryGeneric<Role>, IRol
{
    public RolRepository(CompanyContext context) : base(context)
    {
    }

    public  async  Task<Role> GetById(int Id)
    {
        return await _Context.Set<Role>().FirstOrDefaultAsync(x => x.RoleId == Id);
    }
}