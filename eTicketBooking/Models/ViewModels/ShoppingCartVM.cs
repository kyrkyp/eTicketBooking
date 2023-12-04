using eTickets.Data.Cart;

namespace eTicketBooking.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public ShoppingCart ShoppingCart { get; set; }

        public double ShoppingCartTotal { get; set; }
    }
}