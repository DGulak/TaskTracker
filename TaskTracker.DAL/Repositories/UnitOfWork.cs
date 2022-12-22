using Microsoft.EntityFrameworkCore;
using TaskTracker.DAL.Data;
using TaskTracker.Infrastructures.Contracts;
using TaskTracker.Infrastructures.Entities;

namespace TaskTracker.DAL.Repositories
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(TaskTrackerContext dbContext)
        {
            Repository = new Repository<TEntity>(dbContext);

            _dbContext = dbContext;
        }

        public IRepository<TEntity> Repository { get; }

        public void Dispose()
        {
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
