using MindMateJourney.Application.Repositories;
using MindMateJourney.Domain.Entities;
using MindMateJourney.Persistance.Abstractions;
using MindMateJourney.Persistance.Context;

namespace MindMateJourney.Persistance.Repositories;

public sealed class ContentRepository : Repository<Content>, IContentRepository
{
    public ContentRepository(AppDbContext context) : base(context)
    {
    }
}
