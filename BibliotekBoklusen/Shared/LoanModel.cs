using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    public class LoanModel
    {
        public int Id { get; set; }
        
        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public UserModel? User { get; set; }

        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }
        public ProductModel? Product { get; set; }

        public DateTime LoanDate { get; set; } = DateTime.Now;
        public DateTime ReturnDate { get; set; }

       

         









    }
}
