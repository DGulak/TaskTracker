using Microsoft.EntityFrameworkCore;
using TaskTracker.DAL.Contracts;
using TaskTracker.DAL.Models;

namespace TaskTracker.DAL.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(DbContext dbContext)
        {
            Projects = new Repository<Models.Project>(dbContext);
            Tasks = new Repository<Models.Task>(dbContext);

            _dbContext = dbContext;
        }
        public IRepository<Project> Projects { get; }

        public IRepository<Models.Task> Tasks { get; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
