using Dextra.Marvel.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dextra.Marvel.Infra.Data
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public Task<EntityEntry<TEntity>> AddAsync(TEntity obj)
        {
            return  _context.Set<TEntity>().AddAsync(obj);
        }

        public Task AddAsync(IEnumerable<TEntity> objs)
        {
            return _context.Set<TEntity>().AddRangeAsync(objs);
        }

        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }

        public void Remove(IEnumerable<TEntity> objs)
        {
            _context.Set<TEntity>().RemoveRange(objs);
        }

        public void Update(TEntity obj)
        {
            _context.Set<TEntity>().Update(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where)
        {
            return _context.Set<TEntity>().AnyAsync(where);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> GetAsync(int id)
        {
            return _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(where);
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(where).ToListAsync();
        }

        //public Task<IPagedList<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> order, int pageNumber, int pageSize)
        //{
        //    return _context.Set<TEntity>()
        //        .Where(where)
        //        .OrderBy(order)
        //        .ToPagedListAsync(pageNumber, pageSize);
        //}

        //public Task<IPagedList<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, TKey>> order, int pageNumber, int pageSize)
        //{
        //    return _context.Set<TEntity>()
        //       .OrderBy(order)
        //       .ToPagedListAsync(pageNumber, pageSize);
        //}

        public IQueryable<TEntity> Query
        {
            get { return _context.Set<TEntity>(); }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
