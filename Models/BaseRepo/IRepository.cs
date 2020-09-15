using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BcuV0._3.Models.BaseRepo
{
    public interface IRepository<T> where T : class
    {
        public void Add(T entity);
        public void AddRange(IEnumerable<T> entities);
        public T GetById(int Id);
        public IEnumerable<T> GetAll();
        public void Update(T entity);
        public void Delete(T entity);
        public void DeleteRange(IEnumerable<T> entities);
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

    }
}
