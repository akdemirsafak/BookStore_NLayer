namespace BookStore.Core.Entity;

public class Discipline
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<BookDiscipline> Books { get; set; }
}