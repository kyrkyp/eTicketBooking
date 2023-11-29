namespace eTicketBooking.Models.ViewModels
{
    public class NewMovieDropdownVM
    {
        public List<Producer> Producers { get; set; }

        public List<Cinema> Cinemas { get; set; }

        public List<Actor> Actors { get; set; }

        public NewMovieDropdownVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }
    }
}