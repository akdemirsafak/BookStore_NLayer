namespace BookStore.Core.Entity;

public class Book:BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateOnly PublishDate  { get; set; }
    public virtual List<Discipline> Disciplines { get; set; }
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }
}