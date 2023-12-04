using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eTicketBooking.Models.Registry;

namespace eTicketBooking.Models.Orders
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        #region Navigation Properties

        public string UserId { get; set; }

        #endregion Navigation Properties

        #region Related Entities

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        #endregion Related Entities
    }
}