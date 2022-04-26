using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublishYear { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public bool Reserved { get; set; }
    }
}
