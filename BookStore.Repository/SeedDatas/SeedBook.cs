using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Repository.SeedDatas;

public class SeedBook : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
            new Book
            {
                Id = 1, Title = "Hayvan Çiftliği", Price = 14.68m, AuthorId = 1,
                PublishDate = DateTime.Now.Date.AddYears(-10), CreationDate = DateTime.Now.Date
            }, //1
            new Book
            {
                Id = 2, Title = "Dönüşüm", Price = 14, AuthorId = 2, PublishDate = DateTime.Now.Date.AddYears(-50),
                CreationDate = DateTime.Now.Date.AddDays(-1)
            }, //1
            new Book
            {
                Id = 3, Title = "Dokuzuncu Hariciye Koğuşu",
                Description = "Her gün hastane odalarında ve koridorlarda geçen gençlik yılları...", Price = 24.17m,
                AuthorId = 3, PublishDate = DateTime.Now.AddYears(-150), CreationDate = DateTime.Now.Date.AddYears(-1)
            },
            new Book
            {
                Id = 4, Title = "Sherlock Holmes", Price = 113.75m, AuthorId = 4,
                PublishDate = DateTime.Now.Date.AddYears(-25), CreationDate = DateTime.Now.Date.AddMonths(-6)
            },
            new Book
            {
                Id = 5, Title = "Bir İdam Mahkumunun Son Günü",
                Description = "Öleceğiniz Günü Bilseydiniz Ne Yapardınız? Suç İşlemek Hastalık mıdır?", Price = 14.33m,
                AuthorId = 5, PublishDate = DateTime.Now.Date.AddYears(-65),
                CreationDate = DateTime.Now.Date.AddYears(-10)
            },
            new Book
            {
                Id = 6, Title = "Cingöz Recai", Price = 90, AuthorId = 3, PublishDate = DateTime.Today,
                CreationDate = DateTime.Now.Date.AddDays(-5)
            },
            new Book
            {
                Id = 7, Title = "Notre Dame'ın Kamburu", Description = "", Price = 41, AuthorId = 5,
                PublishDate = DateTime.Today, CreationDate = DateTime.Now.Date.AddMonths(-1)
            },
            new Book
            {
                Id = 8, Title = "Sefiller",
                Description =
                    "Olay örgüsünde birçok ilginç karakterin yer aldığı Sefiller birçok sinema, televizyon ve tiyatro eserine uyarlanmıştır.",
                Price = 11.90m, AuthorId = 5, PublishDate = DateTime.Now.Date.AddYears(-200),
                CreationDate = DateTime.Now.Date.AddMonths(-20)
            }
        );
    }
}