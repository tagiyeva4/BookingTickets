using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BookingTickets.DataAccess.Repositories.Abstractions.Generic
{
    public interface IRepository<TEntity> where TEntity : class
    {
       Task<List<TEntity>> GetAllAsync(params string[] includes);
       Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddManyAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
       Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
