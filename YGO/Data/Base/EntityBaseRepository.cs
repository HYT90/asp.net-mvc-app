using Microsoft.EntityFrameworkCore;
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

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task<T> UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
