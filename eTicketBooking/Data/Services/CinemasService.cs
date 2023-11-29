using eTicketBooking.Data.Base;
using eTicketBooking.Data.Services.Contracts;
using eTicketBooking.Models;

namespace eTicketBooking.Data.Services
{
    public class CinemasService : BaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}