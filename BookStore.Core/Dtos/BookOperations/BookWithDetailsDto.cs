namespace BookStore.Core.Dtos.BookOperations;

public class BookWithDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string PublishDate { get; set; }
    public string CreationDate { get; set; }
    public string? UpdatedDate { get; set; }
    public AuthorForBookDetails Author { get; set; }
    public List<DisciplinesForBookDetails> Disciplines { get; set; }
}

public class AuthorForBookDetails
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
}

public class DisciplinesForBookDetails
{
    public int Id { get; set; }
    public string Name { get; set; }
}