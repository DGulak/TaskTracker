namespace TaskTracker.DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Models.Project> Projects { get; }
        IRepository<Models.Task> Tasks { get; }
        Task<int> SaveChangesAsync();
    }
}
