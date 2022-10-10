namespace BookStore.Core.Dtos.AuthorDtos;

public class AuthorWithBooksDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public List<AuthorBooksDto> Books { get; set; } //Buraya özel dto oluşturulmalı.
}

public class AuthorBooksDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}