using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    public class Fine
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Loan))]
        public int? LoanId { get; set; }
        public LoanModel? Loan { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public UserModel? User  {get; set;}

        public DateTime FineDate { get; set; }
        public double FineAmount { get; set; }
    }
}
