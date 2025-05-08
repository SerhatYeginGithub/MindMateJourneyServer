using MindMateJourney.Domain.Abstraction;

namespace MindMateJourney.Application.DTOS;

public sealed class ContentDto : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public byte[]? Image { get; set; }
    public string CategoryId { get; set; }
}