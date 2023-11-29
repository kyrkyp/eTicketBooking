using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eTicketBooking.Models.ViewModels
{
    public class RegisterVM
    {
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}