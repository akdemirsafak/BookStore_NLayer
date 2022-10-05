using System.Reflection;
using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository;

public class BookStoreDBContext : DbContext
{
    private static bool _created;

    public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options)
    {
        if (!_created)
        {
            _created = true;
            Database.EnsureCreated();
        }
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<BookDiscipline>()
            .HasKey(bd => new { bd.BookId, bd.DisciplineId });

        modelBuilder.Entity<BookDiscipline>()
            .HasOne(bd => bd.Book)
            .WithMany(b => b.Disciplines)
            .HasForeignKey(bd => bd.BookId);

        modelBuilder.Entity<BookDiscipline>()
            .HasOne(bd => bd.Discipline)
            .WithMany(b => b.Books)
            .HasForeignKey(bd => bd.DisciplineId);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var item in ChangeTracker.Entries())
            if (item.Entity is BaseEntity entityReference)
                switch (item.State)
                {
                    case EntityState.Added:
                    {
                        entityReference.CreationDate = DateTime.Now;
                        break;
                    }
                    case EntityState.Modified:
                    {
                        Entry(entityReference).Property(x => x.CreationDate).IsModified = false;
                        entityReference.UpdatedDate = DateTime.Now;
                        break;
                    }
                }

        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        foreach (var item in ChangeTracker.Entries())
            if (item.Entity is BaseEntity entityReference)
                switch (item.Entity)
                {
                    case EntityState.Added:
                    {
                        entityReference.CreationDate = DateTime.Now.Date;
                        break;
                    }
                    case EntityState.Modified:
                    {
                        entityReference.UpdatedDate = DateTime.Now;
                        break;
                    }
                }

        return base.SaveChanges();
    }
}