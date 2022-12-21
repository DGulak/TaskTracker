using Microsoft.EntityFrameworkCore;
using TaskTracker.DAL.Contracts;
using TaskTracker.DAL.Data;
using TaskTracker.Infrastructure.Entities;

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
            _dbContext.SaveChanges();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
