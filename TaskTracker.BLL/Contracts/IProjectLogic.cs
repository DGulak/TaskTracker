
using System.Linq.Expressions;
using TaskTracker.Infrastructure.Entities;
using TaskTracker.Infrastructure.Filters;

namespace TaskTracker.BLL.Contracts
{
    public interface IProjectLogic : IBaseLogic<Project>
    {
        IEnumerable<Project> GetAll(GetAllProjectsFilter filter = null);
        IEnumerable<Project> Where(Expression<Func<Project, bool>> predicate);
    }
}
