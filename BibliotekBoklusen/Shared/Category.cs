﻿namespace BibliotekBoklusen.Shared
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool isChecked { get; set; }

        public List<ProductModel>? Products { get; set; } 
    }
}
