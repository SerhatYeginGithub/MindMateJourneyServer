using System.ComponentModel.DataAnnotations.Schema;
using MindMateJourney.Domain.Entities;

namespace MindMateJourney.Application.DTOS;

public sealed record GetCategoryByIdDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<ContentDto> Contents { get; set; } = new List<ContentDto>();
    public GetCategoryByIdDto(string Id, string Name, List<ContentDto> Contents)
    {
        this.Id = Id;
        this.Name = Name;
        this.Contents = Contents;
    }
}