using EasyChords.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyChords.Data
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        EasyChordsDbContext _dbContext;
        DbSet<TEntity> _DbSet;
        public EFGenericRepository(EasyChordsDbContext context)
        {
            _dbContext = context;
            _DbSet = context.Set<TEntity>();
        }
        public void Add(TEntity entity)
        {
            _DbSet.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State= EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            _DbSet.Remove(entity);
            _dbContext.SaveChanges();
        }
        public TEntity FindById(int id)
        {
            return _DbSet.Find(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _DbSet.AsNoTracking().ToList();
        }
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _DbSet.AsNoTracking().Where(predicate).ToList();
        }
        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _DbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
