using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekBoklusen.Shared
{
    public class ReservationModel
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public UserModel? User { get; set; } 

        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }
        public ProductModel? Product { get; set; }

        public DateTime ReservationDate { get; set; }

        [ForeignKey(nameof(Reservation))]
        public int? ReservationStatusId { get; set; }
        public ReservationModel? Reservation { get; set; }   
    }
}
