namespace MindMateJourney.Application.Repositories;

public interface IUnitOfWork
{
   public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public int SaveChanges();
}