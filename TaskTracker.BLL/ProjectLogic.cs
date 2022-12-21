using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using TaskTracker.BLL.Contracts;
using TaskTracker.DAL.Contracts;
using TaskTracker.Infrastructure.Entities;
using TaskTracker.Infrastructure.Filters;

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

            if (filter?.StartDate != DateTime.MinValue)
                queriable = queriable.Where(p => p.StartDate == filter.StartDate);

            if(filter?.CompletionDate != DateTime.MinValue)
                queriable = queriable.Where(p => p.CompletionDate == filter.CompletionDate);


            return queriable;
        }

        public IEnumerable<Project> Where(Expression<Func<Project, bool>> predicate)
        {
            return _unitOfWork.Repository.GetAll().Where(predicate);
        }
    }
}
