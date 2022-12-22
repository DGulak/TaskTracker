
using System.Linq.Expressions;
using TaskTracker.Infrastructures.Entities;
using TaskTracker.Infrastructures.Filters;

namespace TaskTracker.BLL.Contracts
{
    public interface IProjectLogic : IBaseLogic<Project>
    {
        IEnumerable<Project> GetAll(GetAllProjectsFilter filter = null);
        IEnumerable<Project> Where(Expression<Func<Project, bool>> predicate);
    }
}
