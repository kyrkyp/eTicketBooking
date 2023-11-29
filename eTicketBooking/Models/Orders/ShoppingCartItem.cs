using System.ComponentModel.DataAnnotations;

namespace eTicketBooking.Models.Orders
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public Movie Movie { get; set; }
    }
}