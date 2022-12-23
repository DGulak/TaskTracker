using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TaskTracker.BLL.Contracts;
using TaskTracker.Infrastructures.Contracts;
using TaskTracker.Infrastructures.Entities;
using TaskTracker.Infrastructures.Filters;

namespace TaskTracker.BLL
{
    public class ProjectLogic : BaseLogic<IUnitOfWork<Project>, Project>, IProjectLogic
    {
        public ProjectLogic(
            IUnitOfWork<Project> unitOfWork,
            ILogger<ProjectLogic> logger)
            : base(unitOfWork, logger)
        {

        }

        public IEnumerable<Project> GetAll(GetAllProjectsFilter filter = null)
        {

            var queriable = _unitOfWork.Repository.GetAll();

            if (filter?.Name != null)
                queriable = queriable.Where(p => p.Name == filter.Name);

            if (filter?.StartDate != null)
                queriable = queriable.Where(p => p.StartDate == filter.StartDate);

            if (filter?.CompletionDate != null)
                queriable = queriable.Where(p => p.CompletionDate == filter.CompletionDate);

            if (filter?.Priority != null)
                queriable = queriable.Where(p => p.Priority == filter.Priority);

            if (filter?.ProjectStatus != null)
                queriable = queriable.Where(p => p.ProjectStatus == filter.ProjectStatus);

            return queriable;
        }

        public IEnumerable<Project> Where(Expression<Func<Project, bool>> predicate)
        {
            return _unitOfWork.Repository.GetAll().Where(predicate);
        }
    }
}
