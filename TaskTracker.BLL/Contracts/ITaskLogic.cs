
using System.Linq.Expressions;

namespace TaskTracker.BLL.Contracts
{
    public interface ITaskLogic : IBaseLogic<Infrastructures.Entities.Task>
    {
        IEnumerable<Infrastructures.Entities.Task> Where(Expression<Func<Infrastructures.Entities.Task, bool>> predicate);

        void AssignTask(int newProjectId, int taskId);
        void RemoveTask(int taskId);
    }
}
