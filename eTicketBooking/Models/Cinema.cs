using System.ComponentModel.DataAnnotations;
using eTicketBooking.Data.Base.Contracts;

namespace eTicketBooking.Models
{
    public class Cinema : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Cinema Name")]
        public string Name { get; set; }

        [Display(Name = "Cinema Address")]
        public string Address { get; set; }

        [Display(Name = "Cinema Logo")]
        public string LogoURL { get; set; }

        [Display(Name = "Cinema Description")]
        public string Description { get; set; }

        #region Related Entities

        public ICollection<Movie> Movies { get; set; }

        #endregion Related Entities
    }
}