using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BcuV0._3.Models.BaseRepo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;

        public Repository(DbContext context)
        {
            this._entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            this._entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            this._entities.AddRange(entities);
        }

        public void Delete(T entity)
        {
            this._entities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            this._entities.RemoveRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return
                this._entities.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return this._entities;
        }

        public T GetById(int Id)
        {
            return
                this._entities.Find(Id);
        }

        public void Update(T entity)
        {
            this._entities.Update(entity);
        }
    }
}
