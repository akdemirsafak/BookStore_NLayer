namespace BookStore.Core.Dtos.BookDtos;

public class CreateBookDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public DateTime? PublishDate { get; set; }
    public List<BookDisciplineIdDto> Disciplines { get; set; }
    public int AuthorId { get; set; }
}