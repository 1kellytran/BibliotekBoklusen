using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekBoklusen.Shared
{
    public class Reservation
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public DateTime ReservationDate { get; set; }

        [ForeignKey(nameof(ReservationStatus))]
        public int? ReservationStatusId { get; set; }
        public ReservationStatus? Reservations { get; set; }
    }
}
