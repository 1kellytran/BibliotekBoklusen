using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    public class CreatorModel
    {
      
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<ProductCreatorModel>? ProductCreators { get; set; } = new();


        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }
        public ProductModel? Product { get; set; }


    }
}
