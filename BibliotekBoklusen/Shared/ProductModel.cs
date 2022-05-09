﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekBoklusen.Shared
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public int PublishYear { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public string Type { get; set; } = String.Empty;

        public List<ProductCreatorModel>? ProductCreators { get; set; } = new();
        public List<CreatorModel>? Creators { get; set; }
    }
}
