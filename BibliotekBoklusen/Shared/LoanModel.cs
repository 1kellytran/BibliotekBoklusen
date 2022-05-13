using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekBoklusen.Shared
{
    public class LoanModel
    {
        [Key]
        public int CopyId { get; set; }

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
