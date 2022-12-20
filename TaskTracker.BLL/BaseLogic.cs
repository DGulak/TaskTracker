using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.BLL.Contracts;
using TaskTracker.DAL.Contracts;
using TaskTracker.Models;

namespace TaskTracker.BLL
{
    public class BaseLogic<TRepository, TEntity> : IBaseLogic<TEntity> where TRepository 
        : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly ILogger _logger;

        public BaseLogic(TRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task<TEntity> CreateAsync(TEntity entity)
        {
            return _repository.Create(entity);
        }

        public void Delete(int id)
        {
            var entity = _repository.GetById(id);
            _repository.Delete(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public TEntity Update(TEntity entity)
        {
            _repository.Update(entity);
            return entity;
        }
    }
}
