using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected DatabaseContext DatabaseContext { get; set; }
        public RepositoryBase(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }
        public IQueryable<T> Get() => DatabaseContext.Set<T>().AsNoTracking();
        public T GetByCondition(Expression<Func<T, bool>> expression) => DatabaseContext.Set<T>().Include(expression).FirstOrDefault(expression);
        public void Post(T entity) => DatabaseContext.Set<T>().Add(entity);
        public void Update(T entity) => DatabaseContext.Set<T>().Update(entity);
        public void Delete(T entity) => DatabaseContext.Set<T>().Remove(entity);
        public bool EntityExists(Expression<Func<T, bool>> expression) => DatabaseContext.Set<T>().Any(expression);
    }
}
