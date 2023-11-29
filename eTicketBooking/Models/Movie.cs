using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eTicketBooking.Data.Base.Contracts;
using eTicketBooking.Data.Enums;

namespace eTicketBooking.Models
{
    public class Movie : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        #region Navigation Properties

        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }

        #endregion Navigation Properties

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        #region Related Entities

        public ICollection<Actor_Movie> Actors_Movies { get; set; }

        public Cinema Cinema { get; set; }

        public Producer Producer { get; set; }

        #endregion Related Entities
    }
}