using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekBoklusen.Shared
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obligatorisk fält")]
        public string Title { get; set; } = String.Empty;

        [Required(ErrorMessage = "Obligatorisk fält")]
        public int PublishYear { get; set; }

        //[ForeignKey(nameof(Category))]
        //public int CategoryId { get; set; }
        //public CategoryModel? Category { get; set; }
        public string Type { get; set; } = String.Empty;

        public List<CategoryModel>? Category { get; set; } = new();
        public List<CreatorModel>? Creators { get; set; } = new();
        public List<ProductCreatorModel>? CreatorModels { get; set; } = new();

    }
}
