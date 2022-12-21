
using System.Linq.Expressions;

namespace TaskTracker.BLL.Contracts
{
    public interface ITaskLogic : IBaseLogic<Infrastructure.Entities.Task>
    {
        IEnumerable<Infrastructure.Entities.Task> Where(Expression<Func<Infrastructure.Entities.Task, bool>> predicate);

        void ReassignTask(int newProjectId, int taskId);
    }
}
