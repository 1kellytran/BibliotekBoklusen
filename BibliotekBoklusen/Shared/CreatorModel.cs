using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekBoklusen.Shared
{
    public class CreatorModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }

        public List<ProductCreatorModel>? ProductCreators { get; set; } = new();

        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }
        public ProductModel? Product { get; set; }
    }
}
