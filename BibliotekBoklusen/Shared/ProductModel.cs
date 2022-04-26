using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    public class ProductModel
    {

        //ProductId är primaryKey
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public int PublishYear { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; } = String.Empty;
        public string Genre { get; set; } = String.Empty;
        public bool Reserved { get; set; }

        public List<ProductCreatorModel> ProductCreators { get; set; } = new();
        public List<CreatorModel> Creators { get; set; }

    }
}
