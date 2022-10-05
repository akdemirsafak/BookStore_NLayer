using BookStore.Core.UnitOfWorkCore;

namespace BookStore.Repository.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookStoreDbContext _dbContext;

    public UnitOfWork(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public int Commit()
    {
        return _dbContext.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}