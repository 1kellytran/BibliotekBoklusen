using Microsoft.EntityFrameworkCore;

namespace BibliotekBoklusen.Server.ProductService
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductCreatorModel>> SearchProducts(string searchText)
        {
            return await _context.ProductCreator
                 .Where(p => p.Creator.FirstName.Contains(searchText) || p.Creator.LastName.Contains(searchText) || p.Product.Category.CategoryName.Contains(searchText) || p.Product.Title.Contains(searchText)).ToListAsync();
        }
    }
}
