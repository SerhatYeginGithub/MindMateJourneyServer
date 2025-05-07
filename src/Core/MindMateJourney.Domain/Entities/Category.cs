using MindMateJourney.Domain.Abstraction;

namespace MindMateJourney.Domain.Entities;

public sealed class Category : Entity
{
    public string Name { get; set; }
    
    public ICollection<Content> Contents { get; set; } 
}
