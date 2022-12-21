using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.BLL.Contracts;
using TaskTracker.DAL.Contracts;
using TaskTracker.Infrastructure.Entities;

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

        public Task<TEntity> CreateAsync(TEntity entity)
        {
                return _unitOfWork.Repository.Create(entity);
        }

        public void Delete(int id)
        {
                var entity = _unitOfWork.Repository.GetById(id);
                _unitOfWork.Repository.Delete(entity);
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
