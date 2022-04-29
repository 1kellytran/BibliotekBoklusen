using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    //public enum Type
    //{
    //    Bok = 1,
    //    Ebok = 2,
    //    Film = 3
    //}
    public class ProductModel
    {

        //ProductId är primaryKey
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public int PublishYear { get; set; }
        public int CopiesOwned { get; set; }
        public string CategoryId { get; set; } = String.Empty;

        public List<ProductCreatorModel>? ProductCreators { get; set; } = new();
        public List<CreatorModel>? Creators { get; set; }

    }
}
