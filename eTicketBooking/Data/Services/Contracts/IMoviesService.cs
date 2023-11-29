using eTicketBooking.Data.Base.Contracts;
using eTicketBooking.Models;
using eTicketBooking.Models.ViewModels;

namespace eTicketBooking.Data.Services.Contracts
{
    public interface IMoviesService : IBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);

        Task<NewMovieDropdownVM> GetNewMovieDropdownValues();

        Task AddNewMovieAsync(NewMovieVM data);

        Task UpdateMovieAsync(NewMovieVM data);
    }
}