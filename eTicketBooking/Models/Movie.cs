using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eTicketBooking.Data.Enums;

namespace eTicketBooking.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        #region Related Entities

        public ICollection<Actor> Actors { get; set; }

        public Cinema Cinema { get; set; }

        public Producer Producer { get; set; }

        #endregion Related Entities
    }
}