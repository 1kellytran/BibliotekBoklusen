namespace BibliotekBoklusen.Shared
{
    public class ProductCreatorModel
    {
        public int CreatorId { get; set; }
        public Creator Creator { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
