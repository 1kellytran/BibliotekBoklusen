//using BibliotekBoklusen.Server.Data;
//using BibliotekBoklusen.Server.Services.ProductService;
//using Microsoft.AspNetCore.Mvc;

//namespace TestBoklusen
//{
//    public class UnitTest1
//    {
//        private readonly AppDbContext _context;
        

//        [Fact]
//        public void TestGetAllProducts()
//        {
//            ProductService productService = new(_context);                      //Antal produkter. Kolla mock d�r det �r 5 produkter

//            var products = productService.GetAllProducts();
//            Assert.NotNull(products);
//        }

//        [Fact]
//        public void TestControlId()
//        {
//            ProductService productService = new(_context);                      //Kolla att man f�r en produkt
//            var singleProduct = productService.GetProductById(1);
//            Assert.Equal(1, singleProduct.Id);
//        }
         
//        [Fact]
//        public void TestFailControlId()
//        {
//            ProductService productService = new(_context);                      //Kolla att responsen blir produkten inte existerar 
//            var singleProduct = productService.GetProductById(1);
//            Assert.NotEqual(2, singleProduct.Id);
//        }
//                                                                                //Kolla att det g�r att l�gga till produkt

//                                                                                //Kolla att tillagd produkt finns i listan 

//                                                                                //�ndra produkt med id

//                                                                                //Ta bort produkt och kolla att den inte finns i listan




//    }
//}