using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Repository.SeedDatas;

public class SeedDiscipline : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.HasData(
            new Discipline {Id=1, Name = "Klasik" },
            new Discipline {Id=2, Name = "Edebiyat" },
            new Discipline {Id=3, Name = "Bilim Kurgu" },
            new Discipline {Id=4, Name = "Dergi" },
            new Discipline {Id=5, Name = "Sanat" },
            new Discipline {Id=6, Name = "Diğer" });
    }
}