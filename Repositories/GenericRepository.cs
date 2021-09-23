#nullable enable
using Microsoft.EntityFrameworkCore;
using ShopifyHotelSourcing.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DBContext _context;
        public GenericRepository(DBContext context)
        {
            _context = context;
        }

        public void Add(T entity) => _context.Set<T>().Add(entity);

        public void AddRange(IEnumerable<T> entities) => _context.Set<T>().AddRange(entities);

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression).ToList();

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync().ConfigureAwait(true);

        public T GetById(int id) => _context.Set<T>().Find(id);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public void DeleteRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public async Task<IEnumerable<T>> EntitiesWithEagerLoad(string[] children, Expression<Func<T, bool>>? filter)
        { 
            try
            {
                IQueryable<T> query = _context.Set<T>();
                foreach (var entity in children)
                {
                    query = query.Include(entity);
                }

                if (filter != null)
                {
                    return await query.Where(filter).ToListAsync().ConfigureAwait(true);
                }
                return await query.ToListAsync().ConfigureAwait(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
