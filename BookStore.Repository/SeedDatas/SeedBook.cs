using System.Runtime.InteropServices.JavaScript;
using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Repository.SeedDatas;

public class SeedBook : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasData(
            new Book{Id=1,Title = "Hayvan Çiftliği",Price = 14.68m,AuthorId = 1,PublishDate =DateTime.Now.Date.AddYears(-10) }, //1
            new Book{Id=2,Title = "Dönüşüm",Price = 14,AuthorId = 2,PublishDate =DateTime.Now.Date.AddYears(-50) }, //1
            new Book{Id=3,Title = "Dokuzuncu Hariciye Koğuşu", Description = "Romanın baş karakteri olan on beş yaşındaki çocuk, yaklaşık sekiz senedir dizindeki bir kemik rahatsızlığı nedeniyle tedavi görmektedir. Ancak dizindeki rahatsızlık tam olarak teşhis edilemediği için etkili bir tedavi uygulanması oldukça güçtür. Her gün hastane odalarında ve koridorlarda geçen gençlik yılları, çocuğu gitgide daha çok yıpratır. Bir yandan hastalığının sebep olduğu acılar, bir yandan da tedavi sürecinin belirsizliğinden doğan bunalım onu tedirgin, mutsuz ve özgüvensiz birine dönüştürür. ",Price = 24.17m,AuthorId = 3,PublishDate =DateTime.Now.AddYears(-150) },
            new Book{Id=4,Title = "Sherlock Holmes",Price = 113.75m,AuthorId = 4,PublishDate =DateTime.Now.Date.AddYears(-25) }, //3
            new Book{Id=5,Title = "Bir İdam Mahkumunun Son Günü", Description = "Öleceğiniz Günü Bilseydiniz Ne Yapardınız? Suç İşlemek Hastalık mıdır?",Price = 14.33m,AuthorId = 5,PublishDate = DateTime.Now.Date.AddYears(-65)},
            new Book{Id=6,Title = "Cingöz Recai",Price = 90,AuthorId = 3,PublishDate =DateTime.Today },
            new Book{Id=7,Title = "Notre Dame'ın Kamburu", Description = "",Price = 41,AuthorId = 5,PublishDate = DateTime.Today},
            new Book{Id=8,Title = "Sefiller", Description = "Çok zengin ve yardımsever bir adam olan Madeleine Baba’nın geçmişini, nereden geldiğini kimse bilmiyordu. İri yarı, güçlü, iyi kalpli bir adamdı ve yaptığı ilginç bir buluş sayesinde çok para kazanmıştı. Ancak görünüşe bakılırsa hiç akrabası ya da arkadaşı yoktu. Beklenmedik olayların ardından, fakir ve hasta bir kadına verdiği bir söz, bu ilginç adamın yaşamını ve kimsesiz bir çocuğun kaderini değiştirecekti.  Olay örgüsünde birçok ilginç karakterin yer aldığı Sefiller birçok sinema, televizyon ve tiyatro eserine uyarlanmıştır. Ayrıca bu başyapıt pek çok sanatçıya ilham kaynağı olmuş, ardından yazılan birçok edebi eserde etkisini göstermiştir.  Soluk soluğa okuyacağınız muhteşem bir macera...",Price = 11.90m,AuthorId = 5,PublishDate =DateTime.Now.Date.AddYears(-200) }
            );
    }
}
