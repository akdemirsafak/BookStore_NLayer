namespace BookStore.Core.Dtos.DisciplineDtos;

public class DisciplineWithBooksDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<DisciplineBooksForRelation> Books { get; set; }
}

public class DisciplineBooksForRelation
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string PublishDate { get; set; }
}