namespace BookStore.Core.Dtos.BookOperations;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string PublishDate { get; set; }
    public int AuthorId { get; set; }
    public string CreationDate { get; set; }
    public string? UpdatedDate { get; set; }
}