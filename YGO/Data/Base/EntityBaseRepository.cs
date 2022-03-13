using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YGO.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext appDbContext;
        public EntityBaseRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public async Task AddAsync(T entity)
        {
            await appDbContext.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await appDbContext.Set<T>().FirstOrDefaultAsync(item => item.Id == id);
            EntityEntry entityEntry = appDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await appDbContext.Set<T>().ToListAsync();

            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await appDbContext.Set<T>().FirstOrDefaultAsync(item => item.Id == id);
            return result;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = appDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
        }
    }
}
