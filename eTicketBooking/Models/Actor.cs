using System.ComponentModel.DataAnnotations;
using eTicketBooking.Data.Base.Contracts;

namespace eTicketBooking.Models
{
    public class Actor : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        public string Bio { get; set; }

        #region Related Entities

        public ICollection<Actor_Movie> Actors_Movies { get; set; }

        #endregion Related Entities
    }
}