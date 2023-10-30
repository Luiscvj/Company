using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class TitleRepository : RepositoryGeneric<Title>, ITitle
{
    public TitleRepository(CompanyContext context) : base(context)
    {
    }

    public async Task<Title> GetByTtile_Date(string Title, DateTime Date)
    {
       return await _Context.Set<Title>().FirstOrDefaultAsync(x => x.Title_Id == Title && x.From_Date == Date);
    }
}