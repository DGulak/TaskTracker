using Microsoft.Extensions.Logging;
using TaskTracker.BLL.Contracts;
using TaskTracker.DAL.Contracts;
using TaskTracker.Models;

namespace TaskTracker.BLL
{
    public class ProjectLogic : BaseLogic<IRepository<Project>, Project>, IProjectLogic
    {
        public ProjectLogic(
            IRepository<Models.Project> repository,
            ILogger<ProjectLogic> logger)
            : base(repository, logger)
        {

        }

    }
}
