#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopifyHotelSourcing.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(string id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAllAsNoTracking();

        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        void Update(T entity);

        Task<IEnumerable<T>> EntitiesWithEagerLoad(string[] children, Expression<Func<T, bool>>? filter);

    }
}
