using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Lendory.Data;

namespace Model.Domain;

public abstract class ARepository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext _db;
    protected readonly DbSet<TEntity> _table;

    protected ARepository(ApplicationDbContext db)
    {
        _db = db;
        _table = _db.Set<TEntity>();
    }


    public async Task<TEntity> CreateAsync(TEntity t)
    {
        _table.Add(t);
        await _db.SaveChangesAsync();
        return t;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> list)
    {
        _table.AddRange(list);
        await _db.SaveChangesAsync();
        return list;
    }

    public async Task UpdateAsync(TEntity t)
    {
        _db.ChangeTracker.Clear();
        _table.Update(t);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> list)
    {
        _table.UpdateRange(list);
        await _db.SaveChangesAsync();
    }

    public async Task<TEntity?> ReadAsync(int id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _table.Where(filter).ToListAsync();
    }

    public async Task<List<TEntity>> ReadAsync(int start, int count)
    {
        return await _table.Skip(start).Take(count).ToListAsync();
    }

    public async Task<List<TEntity>> ReadAllAsync()
    {
        return await _table.ToListAsync();
    }

    public async Task DeleteAsync(TEntity t)
    {
        _table.Remove(t);
        await _db.SaveChangesAsync();
    }
}