using Microsoft.EntityFrameworkCore;
using TaskTracker.Infrastructures.Contracts;
using TaskTracker.Infrastructures.Entities;

namespace TaskTracker.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Create(TEntity entity)
        {
            if (entity != null)
            {
                var obj = _dbContext.Add(entity);
                _dbContext.SaveChanges();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
