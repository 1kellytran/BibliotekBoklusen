using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekBoklusen.Shared
{
    public enum ProductType
    {
        Bok = 1,
        [Display(Name = "E-bok")]
        Ebok = 2,
        Ljudbok = 3,
        Film = 4
    }
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorisk fält")]
        public string Title { get; set; } = String.Empty;

        [Required(ErrorMessage = "Obligatorisk fält")]
        [Column(TypeName = "datetime2")]
        public DateTime Published { get; set; }
        public ProductType Type { get; set; }

        public List<Category>? Category { get; set; } = new();
        public List<Creator>? Creators { get; set; } = new();


    }
}
