using System.ComponentModel.DataAnnotations.Schema;
using MindMateJourney.Domain.Abstraction;

namespace MindMateJourney.Domain.Entities;

public sealed class Content : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }

    [ForeignKey("Category")]
    public string CategoryId { get; set; }
    public Category Category { get; set; } 
}
