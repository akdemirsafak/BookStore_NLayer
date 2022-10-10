namespace BookStore.Core.Entity;

public class BookDiscipline : BaseEntity
{
    public int BookId { get; set; }
    public int DisciplineId { get; set; }
    public Book Book { get; set; }
    public Discipline Discipline { get; set; }
}