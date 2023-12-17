
using System.Linq.Expressions;

namespace BookStore.Data.IRepositories;

public interface IGenericRepository<TEntity>
{
    public Task<TEntity> InsertAsync(TEntity entity);

    public Task<TEntity> UpdateAsync(TEntity entity);

    public Task<bool> DeleteAsync(TEntity? entity);

    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null, string[]? include = null);

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null, string[]? include = null);

    public Task SaveChangesAsync();
}
