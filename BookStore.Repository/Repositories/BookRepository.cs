using BookStore.Core.Entity;
using BookStore.Core.RepositoryCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository.Repositories;

public class BookRepository:GenericRepository<Book>,IBookRepository
{
    public BookRepository(BookStoreDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<int> DeleteAsync(int id)
    {
        var result=await _dbContext.Books.Where(b => b.Id == id).ExecuteDeleteAsync();
        return result;
    }

    public int Delete(int id)
    {
        return _dbContext.Books.Where(b => b.Id == id).ExecuteDelete();
    }

    public int Update(Book entity)
    {
        return _dbContext.Books.Where(b => b.Id == entity.Id)
            .ExecuteUpdate(u=>
                u.SetProperty(x => x.Title, y => entity.Title)
                    .SetProperty(x=>x.Description, y => entity.Description)
                    .SetProperty(x=>x.Price, y => entity.Price)
                    .SetProperty(x=>x.AuthorId, y => entity.AuthorId)
                    .SetProperty(x=>x.PublishDate, y => entity.PublishDate)
            );
    } 
    public async Task<int> UpdateAsync(Book entity)
     {
          return await _dbContext.Books.Where(b => b.Id == entity.Id)
              .ExecuteUpdateAsync(u =>
                  u.SetProperty(x => x.Title, y => entity.Title)
                      .SetProperty(x=>x.Description, y => entity.Description)
                      .SetProperty(x=>x.Price, y => entity.Price)
                      .SetProperty(x=>x.AuthorId, y => entity.AuthorId)
                      .SetProperty(x=>x.PublishDate, y => entity.PublishDate)
          );
     }
}