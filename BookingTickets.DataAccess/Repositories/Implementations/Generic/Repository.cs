using BookingTickets.DataAccess.Data.Contexts;
using BookingTickets.DataAccess.Repositories.Abstractions.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookingTickets.DataAccess.Repositories.Implementations.Generic;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly BookingTicketsDbContext _dbContext;
    private readonly DbSet<TEntity> Table;
    public Repository(BookingTicketsDbContext dbContext)
    {
        _dbContext = dbContext;
        Table=_dbContext.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        Table.Add(entity);
        await _dbContext.SaveChangesAsync();

    }

    public async Task AddManyAsync(IEnumerable<TEntity> entities)
    {
        Table.AddRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return Table.Any(predicate);
    }

    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return Table.Count(predicate);

    }

    public async Task DeleteAsync(TEntity entity)
    {
        Table.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteManyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entities = Find(predicate);
        Table.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return Table.Where(predicate);
    }

    public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> predicate, params string[] includes)
    {
        var query = Table.AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        var result = await query.FirstOrDefaultAsync(predicate);

        return result;

    }

    public async Task<List<TEntity>> GetAllAsync(params string[] includes)
    {
        var query =Table.AsQueryable();
        foreach (var include in includes)
        {
            query = query.Include(include);  //Select*from Books b join Author a on b.AuthorId=a.Id  join Sales s  on b.SalesId=s.Id  join Customer c s.CustomerId=c.Id 
        }
        var result = await query.ToListAsync(); //List<Book> books

        return result;

    }

    public async Task UpdateAsync(TEntity entity)
    {
        Table.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var query = Table.AsQueryable();

        var result = await query.AnyAsync(predicate);

        return result;
    }
}
