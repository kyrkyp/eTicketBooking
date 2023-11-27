using System.ComponentModel.DataAnnotations;

namespace eTicketBooking.Models
{
	public class Cinema
	{
		[Key]
		public int CinemaId { get; set; }

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