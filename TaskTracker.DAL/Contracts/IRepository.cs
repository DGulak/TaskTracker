using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.DAL.Contracts
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        public TEntity Create(TEntity _object);
        public void Delete(TEntity _object);
        public void Update(TEntity _object);
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(int Id);
    }
}
