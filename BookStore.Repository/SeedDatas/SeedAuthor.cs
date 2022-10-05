using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Repository.SeedDatas;

public class SeedAuthor : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasData(
            new Author { Id=1,Name = "George", LastName = "Orwell" },
            new Author { Id=2,Name = "Franz", LastName = "Kafka" },
            new Author { Id=3,Name = "Peyami", LastName = "Safa" },
            new Author { Id=4,Name = "Sir Arthur Conan", LastName = "Doyle" },
            new Author { Id=5,Name = "Viktor", LastName = "Hugo" });
    }
}