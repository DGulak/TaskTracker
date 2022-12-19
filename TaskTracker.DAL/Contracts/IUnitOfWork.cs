
namespace TaskTracker.DAL.Contracts
{
    internal interface IUnitOfWork : IDisposable
    {
        IRepository<Models.Project> Projects { get; }
        IRepository<Models.Task> Tasks { get; }
    }
}
