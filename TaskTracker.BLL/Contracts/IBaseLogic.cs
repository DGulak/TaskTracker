using TaskTracker.Infrastructures.Entities;

namespace TaskTracker.BLL.Contracts
{
    public interface IBaseLogic<TEntity> : IDisposable where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
