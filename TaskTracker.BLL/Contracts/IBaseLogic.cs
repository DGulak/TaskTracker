using TaskTracker.Infrastructure.Entities;

namespace TaskTracker.BLL.Contracts
{
    public interface IBaseLogic<TEntity> : IDisposable where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
