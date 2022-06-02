using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    public class LoansByUserDTO
    {
        public int UserId { get; set; }
        public int LoansCount { get; set; }
    }
}
