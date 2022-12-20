
namespace TaskTracker.DAL.Contracts
{
    /// <summary>
    /// Generic Repository interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        public Task<TEntity> Create(TEntity entity);
        public void Delete(TEntity entity);
        public void Update(TEntity entity);
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(int id);
    }
}
