using GenericRepository;
using MindMateJourney.Application.Repositories;
using MindMateJourney.Domain.Entities;
using MindMateJourney.Persistance.Context;

namespace MindMateJourney.Persistance.Repositories;

public sealed class CategoryRepository : Repository<Category, AppDbContext>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
