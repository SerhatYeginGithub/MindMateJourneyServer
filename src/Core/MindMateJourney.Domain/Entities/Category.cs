using MindMateJourney.Domain.Abstraction;

namespace MindMateJourney.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; set; }
    
    ICollection<Content> Contents { get; set; }
}
