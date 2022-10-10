using BookStore.Core.Entity;
using BookStore.Core.RepositoryCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(BookStoreDBContext dbContext) : base(dbContext)
    {
    }

    public async Task<Author> GetWithBooksByIdAsync(int id)
    {
        return await _dbContext.Authors.Where(x => x.Id == id).Include(x => x.Books).SingleOrDefaultAsync();
    }

    public async Task<int> UpdateAsync(Author author)
    {
        var affectedRowCount = await _dbContext.Authors.Where(x => x.Id == author.Id)
            .ExecuteUpdateAsync(a =>
                a.SetProperty(x => x.Name, y => author.Name)
                    .SetProperty(x => x.LastName, y => author.LastName));
        return affectedRowCount;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var affectedRowCount = await _dbContext.Authors.Where(x => x.Id == id).ExecuteDeleteAsync();
        return affectedRowCount;
    }
}