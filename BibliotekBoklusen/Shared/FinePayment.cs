using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekBoklusen.Shared
{
    public class FinePayment
    {
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public User? User { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }
    }
}
