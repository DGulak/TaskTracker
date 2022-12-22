using TaskTracker.Infrastructures.Entities;

namespace TaskTracker.Infrastructures.Contracts
{
    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : BaseEntity
    {
        IRepository<TEntity> Repository { get; }
        int SaveChanges();
    }
}
