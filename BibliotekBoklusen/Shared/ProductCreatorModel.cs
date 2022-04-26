﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekBoklusen.Shared
{
    public class ProductCreatorModel
    {
        public int CreatorId { get; set; }
        public CreatorModel Creator { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
    }
}
