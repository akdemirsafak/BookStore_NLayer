namespace BookStore.Core.Entity;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishDate { get; set; }
    public List<BookDiscipline> Disciplines { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}