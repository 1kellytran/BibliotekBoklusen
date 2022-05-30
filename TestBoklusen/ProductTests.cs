namespace TestBoklusen
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            BibliotekBoklusen.Server.Controllers.ProductsController test = new();
            var singleProducts=test.GetProductById(1);

            Assert.NotNull(singleProducts);         
           

        }
    }
}