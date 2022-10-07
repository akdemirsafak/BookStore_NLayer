using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Repository.SeedDatas;

public class SeedBookDiscipline : IEntityTypeConfiguration<BookDiscipline>
{
    public void Configure(EntityTypeBuilder<BookDiscipline> builder)
    {
        builder.HasData(
            new BookDiscipline { BookId = 1, DisciplineId = 3 },
            new BookDiscipline { BookId = 2, DisciplineId = 6 },
            new BookDiscipline { BookId = 2, DisciplineId = 4 },
            new BookDiscipline { BookId = 3, DisciplineId = 5 },
            new BookDiscipline { BookId = 4, DisciplineId = 1 },
            new BookDiscipline { BookId = 5, DisciplineId = 1 },
            new BookDiscipline { BookId = 6, DisciplineId = 2 },
            new BookDiscipline { BookId = 7, DisciplineId = 5 },
            new BookDiscipline { BookId = 7, DisciplineId = 2 },
            new BookDiscipline { BookId = 8, DisciplineId = 2 },
            new BookDiscipline { BookId = 8, DisciplineId = 1 }
        );
    }
}