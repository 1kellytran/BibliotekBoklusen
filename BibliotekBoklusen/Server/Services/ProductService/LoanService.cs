using BibliotekBoklusen.Client.Services;

namespace BibliotekBoklusen.Server.Services.ProductService
{
    public class LoanService : ILoanService
    {
        private readonly AppDbContext _context;

        public LoanService(AppDbContext context)
        {
            _context = context;

        }
        public ProductCopy productCopyn { get; set; }

        public async Task<Loan> CreateLoan(int productId, int userId)
        {
            var prodcop = _context.productCopies.Where(pc => pc.ProductId == productId && pc.IsLoaned == false).ToList();
            productCopyn = prodcop.FirstOrDefault(pc => pc.ProductId == productId);
            productCopyn.IsLoaned = true;
            _context.productCopies.Update(productCopyn);
            _context.SaveChanges();
            if (productCopyn != null)
            {
                Loan loan = new();
                loan.ProductCopyId = productCopyn.Id;
                loan.UserId = userId;
                return loan;
            }
            else
            {
                return null;
            }
            
        }
        
    }
}
