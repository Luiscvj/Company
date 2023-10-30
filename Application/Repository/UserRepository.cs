using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class UserRepository : RepositoryGeneric<User>, IUser
{
    public UserRepository(CompanyContext context) : base(context)
    {
    }

    public async  Task<User> GetById(int Id)
    {
        return await _Context.Set<User>().FirstOrDefaultAsync(x => x.UserId == Id);
    }

    public async Task<User> GetByUserName(string userName)
    {
        return await _Context.Set<User>().FirstOrDefaultAsync(x => x.Username.ToLower() == userName.ToLower());
    }
}