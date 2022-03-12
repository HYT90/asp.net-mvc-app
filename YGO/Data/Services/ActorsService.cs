using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YGO.Models;

namespace YGO.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext appDbContext;
        public ActorsService(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public async Task AddAsync(Actor actor)
        {
            await appDbContext.Actors.AddAsync(actor);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await appDbContext.Actors.FirstOrDefaultAsync(item => item.Id == id);
            appDbContext.Actors.Remove(result);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await appDbContext.Actors.ToListAsync();

            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await appDbContext.Actors.FirstOrDefaultAsync(item => item.Id == id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            appDbContext.Update(newActor);
            await appDbContext.SaveChangesAsync();

            return newActor;
        }
    }
}
