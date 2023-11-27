using System.ComponentModel.DataAnnotations;

namespace eTicketBooking.Models
{
	public class Actor
	{
		[Key]
		public int ActorId { get; set; }

		[Display(Name = "Profile Picture")]
		public string ProfilePictureURL { get; set; }

		[Display(Name = "Full Name")]
		public string FullName { get; set; }

		[Display(Name = "Biography")]
		public string Bio { get; set; }

		#region Related Entities

		public ICollection<Movie> Movies { get; set; }

		#endregion Related Entities
	}
}