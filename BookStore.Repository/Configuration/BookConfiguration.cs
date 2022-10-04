using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Repository.Configuration;

public class BookConfiguration:IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasMaxLength(128);
        builder.Property(x => x.Description).HasMaxLength(1024);
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x => x.CreationDate).ValueGeneratedOnAdd();
        builder.Property(x => x.UpdatedDate).ValueGeneratedOnUpdate();
        builder.Property(x => x.Disciplines).IsRequired();
    }
}