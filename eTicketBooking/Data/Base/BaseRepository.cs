using eTicketBooking.Data.Base.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTicketBooking.Data.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        private readonly AppDbContext _dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _dbContext.Set<T>().ToListAsync();

            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbContext.Set<T>().FirstOrDefaultAsync(a => a.Id == id);

            return result;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _dbContext.Entry<T>(entity);

            entityEntry.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbContext.Set<T>().FirstOrDefaultAsync(a => a.Id == id);

            _dbContext.Set<T>().Remove(result);

            await _dbContext.SaveChangesAsync();
        }
    }
}