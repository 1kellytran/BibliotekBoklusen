using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    public class ProductCategory
    {
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
       
        [Key, Column(Order = 2)]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
      
    }
}
