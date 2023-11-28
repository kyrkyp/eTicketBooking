using eTicketBooking.Data.Services.Contracts;
using eTicketBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace eTicketBooking.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _dbContext;

        public ActorsService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Actor> CreateAsync(Actor actor)
        {
            await _dbContext.Actors.AddAsync(actor);

            await _dbContext.SaveChangesAsync();

            return actor;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbContext.Actors.FirstOrDefaultAsync(a => a.ActorId == id);

            _dbContext.Actors.Remove(result);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _dbContext.Actors.ToListAsync();

            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _dbContext.Actors.FirstOrDefaultAsync(a => a.ActorId == id);

            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            var actorToUpdate = await GetByIdAsync(id);

            actorToUpdate.FullName = newActor.FullName;
            actorToUpdate.Bio = newActor.Bio;
            actorToUpdate.ProfilePictureURL = newActor.ProfilePictureURL;

            await _dbContext.SaveChangesAsync();

            return actorToUpdate;
        }
    }
}