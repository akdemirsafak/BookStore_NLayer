namespace BookStore.Core.Entity;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}