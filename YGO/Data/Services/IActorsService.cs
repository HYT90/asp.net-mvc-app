using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YGO.Models;

namespace YGO.Data.Services
{
    public interface IActorsService
    {
        public Task<IEnumerable<Actor>> GetAllAsync();
        public Task<Actor> GetByIdAsync(int id);
        public Task AddAsync(Actor actor);
        public Task<Actor> UpdateAsync(int id, Actor newActor);
        public Task DeleteAsync(int id);
    }
}
