
using BookStore.Data.Databases;
using BookStore.Data.IRepositories;
using BookStore.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookStore.Data.Repositories
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> 
        where Tentity : Auditable
    {
        private readonly AppDbContext appDbContext;
        private readonly DbSet<Tentity> dbSet;

        public GenericRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            this.dbSet = appDbContext.Set<Tentity>();
        }

        public async Task<bool> DeleteAsync(Tentity? entity)
        {
            await Task.Run(() => this.dbSet.Remove(entity));
            await SaveChangesAsync();
            return true;
        }

        public IQueryable<Tentity> GetAll(Expression<Func<Tentity, bool>> expression = null, string[]? includes = null)
        {
            IQueryable<Tentity> entities = expression is null ? dbSet : dbSet.Where(expression);

            if (includes is not null) 
            {
                foreach (var include in includes) 
                    entities = entities.Include(include);
            }
            return entities;   
        }

        public async Task<Tentity> GetAsync(Expression<Func<Tentity, bool>> expression = null, string[]? includes = null)
        {
            var query = dbSet.Where(expression);

            if (includes is not null) 
            {
                foreach(var include in includes)
                    query = query.Include(include);
            }
             
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Tentity> InsertAsync(Tentity entity) 
        {
            var entry = await this.dbSet.AddAsync(entity);
            await SaveChangesAsync();
            return entry.Entity;
        }    

        public async Task SaveChangesAsync()
        {
            await this.appDbContext.SaveChangesAsync();
        }

        public async Task<Tentity> UpdateAsync(Tentity entity)
        {
            var result = await Task.Run(() => this.dbSet.Update(entity));
            await SaveChangesAsync();

            return result.Entity;
        }
    }
}
