using Khan.DataBase.Repository.Interfaces;
using Khan.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Khan.DataBase.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region [Properties]
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            this._context = context;
        }
        #endregion

        #region [Methods]
        public TEntity GetById(Guid Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().SingleOrDefault(filter);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> GetAll(int skip, int take)
        {
            take = take == 0 ? 10 : take;
            return _context.Set<TEntity>().Skip(skip).Take(take).ToList();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Where(filter);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
        #endregion
    }
}
