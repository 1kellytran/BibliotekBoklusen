using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekBoklusen.Shared
{
    public class Fine
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Loan))]
        public int? LoanId { get; set; }
        public Loan? Loan { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public User? User { get; set; }

        public DateTime FineDate { get; set; }
        public double FineAmount { get; set; }
    }
}
