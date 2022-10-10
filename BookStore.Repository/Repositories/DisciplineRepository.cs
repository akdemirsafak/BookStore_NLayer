using BookStore.Core.Entity;
using BookStore.Core.RepositoryCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.Repositories;

public class DisciplineRepository : GenericRepository<Discipline>, IDisciplineRepository
{
    public DisciplineRepository(BookStoreDBContext dbContext) : base(dbContext)
    {
    }

    public async Task<Discipline> GetWithBooksByIdAsync(int id)
    {
        return await _dbContext.Disciplines.Where(x => x.Id == id)
            .Include(x => x.Books).ThenInclude(x => x.Book).SingleOrDefaultAsync();
    }

    public async Task<int> UpdateAsync(Discipline discipline)
    {
        var affectedRowCount = await _dbContext.Disciplines.Where(x => x.Id == discipline.Id)
            .ExecuteUpdateAsync(u =>
                u.SetProperty(x => x.Name, y => discipline.Name));
        return affectedRowCount;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var affectedRowCount = await _dbContext.Disciplines.Where(x => x.Id == id).ExecuteDeleteAsync();
        return affectedRowCount;
    }
}