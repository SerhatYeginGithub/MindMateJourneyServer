using Microsoft.EntityFrameworkCore;
using MindMateJourney.Application.Repositories;
using MindMateJourney.Persistance.Context;
using System.Linq.Expressions;

namespace MindMateJourney.Persistance.Abstractions;

public abstract class Repository<TEntity> : IRepository<TEntity>
       where TEntity : class
{
    private readonly AppDbContext _context;
    private DbSet<TEntity> Entity;

    public Repository(AppDbContext context)
    {
        _context = context;
        Entity = _context.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        Entity.Add(entity);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Entity.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await Entity.AddRangeAsync(entities, cancellationToken);
    }

    public bool Any(Expression<Func<TEntity, bool>> expression)
    {
        return Entity.Any(expression);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await Entity.AnyAsync(expression, cancellationToken);
    }

    public void Delete(TEntity entity)
    {
        Entity.Remove(entity);
    }

    public async Task DeleteByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        TEntity entity = await Entity.Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        Entity.Remove(entity);
    }

    public async Task DeleteByIdAsync(string id)
    {
        TEntity entity = await Entity.FindAsync(id);
        Entity.Remove(entity);
    }

    public void DeleteRange(ICollection<TEntity> entities)
    {
        Entity.RemoveRange(entities);
    }

    public IQueryable<TEntity> GetAll()
    {
        return Entity.AsNoTracking().AsQueryable();
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Entity
            .AsNoTracking()
            //.Where(x => !EF.Property<bool>(x, "IsDeleted"))
            .ToListAsync(cancellationToken);
    }


    public IQueryable<TEntity> GetAllWithTracking()
    {
        return Entity
           // .Where(x => !EF.Property<bool>(x, "IsDeleted"))
            .AsQueryable();
    }

    public TEntity GetByExpression(Expression<Func<TEntity, bool>> expression)
    {
        TEntity entity = Entity.Where(expression).AsNoTracking().FirstOrDefault();
        return entity;
    }

    public async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        TEntity entity = await Entity
            .Where(expression)
            //.Where(x => !EF.Property<bool>(x, "IsDeleted"))
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }


    public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default, bool isTrackingActive = true)
    {
        TEntity entity;
        if (isTrackingActive)
        {
            entity = await Entity.Where(expression).FirstOrDefaultAsync(cancellationToken);
        }
        else
        {
            entity = await Entity.Where(expression).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }

        return entity;
    }

    public TEntity GetByExpressionWithTracking(Expression<Func<TEntity, bool>> expression)
    {
        TEntity entity = Entity.Where(expression).FirstOrDefault();
        return entity;
    }

    public async Task<TEntity> GetByExpressionWithTrackingAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        TEntity entity = await Entity.Where(expression).FirstOrDefaultAsync(cancellationToken);
        return entity;
    }

    public TEntity GetFirst()
    {
        TEntity entity = Entity.AsNoTracking().FirstOrDefault();
        return entity;
    }

    public async Task<TEntity> GetFirstAsync(CancellationToken cancellationToken = default)
    {
        TEntity entity = await Entity.AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        return entity;
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
    {
        return Entity.AsNoTracking()
           // .Where(x => !EF.Property<bool>(x, "IsDeleted"))
            .Where(expression).AsQueryable();
    }

    public IQueryable<TEntity> WhereWithTracking(Expression<Func<TEntity, bool>> expression)
    {
        return Entity
            //.Where(x => !EF.Property<bool>(x, "IsDeleted"))
            .Where(expression).AsQueryable();
    }

    public void Update(TEntity entity)
    {
        Entity.Update(entity);
    }

    public void UpdateRange(ICollection<TEntity> entities)
    {
        Entity.UpdateRange(entities);
    }

    public void AddRange(ICollection<TEntity> entities)
    {
        Entity.AddRange(entities);
    }

    public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression, bool isTrackingActive = true)
    {
        if (isTrackingActive)
        {
            return Entity.FirstOrDefault(expression);
        }

        return Entity.AsNoTracking().FirstOrDefault(expression);
    }

    public TEntity First(Expression<Func<TEntity, bool>> expression, bool isTrackingActive = true)
    {
        if (isTrackingActive)
        {
            return Entity.First(expression);
        }

        return Entity.AsNoTracking().First(expression);
    }

    public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default, bool isTrackingActive = true)
    {
        if (isTrackingActive)
        {
            return await Entity.FirstAsync(expression, cancellationToken);
        }

        return await Entity.AsNoTracking().FirstAsync(expression, cancellationToken);
    }
}
