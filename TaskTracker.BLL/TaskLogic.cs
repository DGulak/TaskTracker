using Microsoft.Extensions.Logging;
using TaskTracker.BLL.Contracts;
using TaskTracker.DAL.Contracts;

namespace TaskTracker.BLL
{
    public class TaskLogic : BaseLogic<IRepository<Models.Task>, Models.Task>, ITaskLogic
    {
        public TaskLogic(
            IRepository<Models.Task> repository,
            ILogger<TaskLogic> logger) 
            : base(repository, logger)
        {

        }
    }
}
