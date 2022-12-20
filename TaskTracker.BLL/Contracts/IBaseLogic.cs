namespace TaskTracker.BLL.Contracts
{
    public interface IBaseLogic<TEntity> where TEntity : Models.BaseEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
