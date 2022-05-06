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
