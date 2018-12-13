using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Khan.DataBase.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(Guid Id);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int skip, int take);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
