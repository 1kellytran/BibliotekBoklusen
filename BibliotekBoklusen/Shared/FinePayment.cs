using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    public class FinePayment
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaymentAmount { get; set; }




    }
}
