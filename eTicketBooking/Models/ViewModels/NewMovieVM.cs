using System.ComponentModel.DataAnnotations;
using eTicketBooking.Data.Enums;

namespace eTicketBooking.Models.ViewModels
{
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Movie name")]
        public string Name { get; set; }

        [Display(Name = "Movie description")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        public double Price { get; set; }

        [Display(Name = "Movie poster URL")]
        public string ImageURL { get; set; }

        [Display(Name = "Movie start date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Movie end date")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        public MovieCategory MovieCategory { get; set; }

        #region Relationship properties

        [Display(Name = "Select actor(s)")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Select a cinema")]
        public int CinemaId { get; set; }

        [Display(Name = "Select a producer")]
        public int ProducerId { get; set; }

        #endregion Relationship properties
    }
}