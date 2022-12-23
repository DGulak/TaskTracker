using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TaskTracker.BLL.Contracts;
using TaskTracker.Infrastructures.Contracts;

namespace TaskTracker.BLL
{
    public class TaskLogic : BaseLogic<IUnitOfWork<Infrastructures.Entities.Task>, Infrastructures.Entities.Task>, ITaskLogic
    {
        public TaskLogic(
            IUnitOfWork<Infrastructures.Entities.Task> unitOfWork,
            ILogger<TaskLogic> logger)
            : base(unitOfWork, logger)
        {

        }

        public void AssignTask(int newProjectId, int taskId)
        {
            var task = _unitOfWork.Repository.GetById(taskId);
            task.ProjectId = newProjectId;
            _unitOfWork.Repository.Update(task);
        }

        public void RemoveTask(int taskId)
        {
            var task = _unitOfWork.Repository.GetById(taskId);
            task.ProjectId = 0;
            _unitOfWork.Repository.Update(task);
        }

        public IEnumerable<Infrastructures.Entities.Task> Where(Expression<Func<Infrastructures.Entities.Task, bool>> predicate)
        {
            return _unitOfWork.Repository.GetAll().Where(predicate);
        }
    }
}
