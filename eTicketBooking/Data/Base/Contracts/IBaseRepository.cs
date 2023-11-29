namespace eTicketBooking.Data.Base.Contracts
{
    public interface IBaseRepository<T> where T : class, IBaseEntity, new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);
    }
}