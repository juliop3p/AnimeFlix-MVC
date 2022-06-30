using AnimeFlix.Business.Entities;
using AnimeFlix.Business.Interfaces;
using AnimeFlix.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AnimeFlix.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly AnimeFlixContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(AnimeFlixContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
