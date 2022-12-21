using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TaskTracker.BLL.Contracts;
using TaskTracker.DAL.Contracts;

namespace TaskTracker.BLL
{
    public class TaskLogic : BaseLogic<IUnitOfWork<Infrastructure.Entities.Task>, Infrastructure.Entities.Task>, ITaskLogic
    {
        public TaskLogic(
            IUnitOfWork<Infrastructure.Entities.Task> unitOfWork,
            ILogger<TaskLogic> logger) 
            : base(unitOfWork, logger)
        {

        }

        public void ReassignTask(int newProjectId, int taskId)
        {
            var task = _unitOfWork.Repository.GetById(taskId);
            task.ProjectId= newProjectId;
            _unitOfWork.Repository.Update(task);
        }

        public IEnumerable<Infrastructure.Entities.Task> Where(Expression<Func<Infrastructure.Entities.Task, bool>> predicate)
        {
            return _unitOfWork.Repository.GetAll().Where(predicate);
        }
    }
}
