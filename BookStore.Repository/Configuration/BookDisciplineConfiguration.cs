using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Repository.Configuration;

public class BookDisciplineConfiguration : IEntityTypeConfiguration<BookDiscipline>
{
    public void Configure(EntityTypeBuilder<BookDiscipline> builder)
    {
        builder.HasKey(x => x.BookId);
        builder.HasKey(x => x.DisciplineId);
    }
}