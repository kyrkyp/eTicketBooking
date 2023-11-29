using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eTicketBooking.Models.ViewModels
{
    public class LoginVM
    {
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}