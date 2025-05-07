using GenericRepository;
using Microsoft.EntityFrameworkCore;
using MindMateJourney.Application.Repositories;
using MindMateJourney.Domain.Entities;
using MindMateJourney.Persistance.Context;

namespace MindMateJourney.Persistance.Repositories;

public sealed class CategoryRepository : Repository<Category, AppDbContext>, ICategoryRepository
{
    private readonly AppDbContext _context;
    public CategoryRepository(AppDbContext context) : base(context)
    {
     _context = context;
    }

    public async Task<Category?> GetByIdWithContentsAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _context.Categories
            .Include(c => c.Contents)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
