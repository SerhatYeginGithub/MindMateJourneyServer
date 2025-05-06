namespace MindMateJourney.Domain.Abstraction;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
