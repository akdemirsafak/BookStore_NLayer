namespace BookStore.Core.Entity;

public class Discipline
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<BookDiscipline> Books { get; set; }
}