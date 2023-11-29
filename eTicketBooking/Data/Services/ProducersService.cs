using eTicketBooking.Data.Base;
using eTicketBooking.Data.Services.Contracts;
using eTicketBooking.Models;

namespace eTicketBooking.Data.Services
{
    public class ProducersService : BaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}