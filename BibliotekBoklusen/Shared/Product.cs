using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekBoklusen.Shared
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorisk fält")]
        public string Title { get; set; } = String.Empty;

        [Required(ErrorMessage = "Obligatorisk fält")]
        public int PublishYear { get; set; }
        public string Type { get; set; } = String.Empty;

        public List<Category>? Category { get; set; } = new();
        public List<Creator>? Creators { get; set; } = new();
       

    }
}
