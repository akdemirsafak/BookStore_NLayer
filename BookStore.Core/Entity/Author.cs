namespace BookStore.Core.Entity;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public virtual List<Book> Books { get; set; }
}