using Microsoft.EntityFrameworkCore;
using TaskTracker.DAL.Contracts;
using TaskTracker.DAL.Models;

namespace TaskTracker.DAL.Repositories
{
    internal class MSSQLUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public MSSQLUnitOfWork(DbContext dbContext)
        {
            Projects = new MSSQLRepository<Models.Project>(dbContext);
            Tasks = new MSSQLRepository<Models.Task>(dbContext);

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
