using System.ComponentModel.DataAnnotations;

namespace eTicketBooking.Models.Orders
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        #region Navigation Properties

        public int MovieId { get; set; }

        public int OrderId { get; set; }

        #endregion Navigation Properties

        #region Related Entities

        public Movie Movie { get; set; }

        public Order Order { get; set; }

        #endregion Related Entities
    }
}