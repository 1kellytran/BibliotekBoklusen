using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    public class Fine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime FineDate { get; set; }
        public Double FineAmount { get; set; }
    }
}
