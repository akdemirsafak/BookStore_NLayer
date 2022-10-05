using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Repository.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(64);
    }
}