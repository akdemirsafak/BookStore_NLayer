namespace BookStore.Core.Entity;

public class BookDiscipline
{
    public Book Book { get; set; }
    public int BookId { get; set; }
    public Discipline Discipline { get; set; }
    public int DisciplineId { get; set; }
    
    
}