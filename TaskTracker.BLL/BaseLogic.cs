using Microsoft.Extensions.Logging;
using TaskTracker.BLL.Contracts;
using TaskTracker.Infrastructures.Contracts;
using TaskTracker.Infrastructures.Entities;

namespace TaskTracker.BLL
{
    public class BaseLogic<TUnitOfWork, TEntity> : IBaseLogic<TEntity> where TUnitOfWork
        : IUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        protected readonly IUnitOfWork<TEntity> _unitOfWork;
        protected readonly ILogger _logger;

        public BaseLogic(TUnitOfWork unitOfWork, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public TEntity Create(TEntity entity)
        {
            var result = _unitOfWork.Repository.Create(entity);
            _unitOfWork.SaveChanges();
            return result;
        }

        public void Delete(int id)
        {
            var entity = _unitOfWork.Repository.GetById(id);
            _unitOfWork.Repository.Delete(entity);
            _unitOfWork.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _unitOfWork.Repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _unitOfWork.Repository.GetById(id);
        }

        public TEntity Update(TEntity entity)
        {
            _unitOfWork.Repository.Update(entity);
            _unitOfWork.SaveChanges();
            return entity;
        }
        public void Dispose()
        {
        }
    }
}
