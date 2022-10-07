namespace BookStore.Core.Dtos.BookOperations;

public class UpdateBookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTime PublishDate { get; set; }
    public int AuthorId { get; set; }
}