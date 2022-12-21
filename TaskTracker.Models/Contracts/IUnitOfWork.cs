using TaskTracker.Infrastructure.Entities;

namespace TaskTracker.DAL.Contracts
{
    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : BaseEntity
    {
        IRepository<TEntity> Repository { get; }
        int SaveChanges();
    }
}
