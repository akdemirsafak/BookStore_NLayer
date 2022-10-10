namespace BookStore.Core.Dtos.BookDtos;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string PublishDate { get; set; }
    public int AuthorId { get; set; }
    public string CreatedDate { get; set; }
    public string? UpdatedDate { get; set; }
}