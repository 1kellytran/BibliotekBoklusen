using Microsoft.EntityFrameworkCore;

namespace BibliotekBoklusen.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<SeminariumModel> Seminariums { get; set; }
        public DbSet<LoanModel> Loans { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
        public DbSet<ReservationStatus> ReservationStatuses { get; set; }
        public DbSet<FinePayment> FinePayments { get; set; }
        public DbSet<Fine> Fines { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           
            modelBuilder.Entity<CategoryModel>()
                .HasData(new CategoryModel() { Id = 1, CategoryName = "Deckare" },
                new CategoryModel() { Id = 2, CategoryName = "Feelgood" },
                new CategoryModel() { Id = 3, CategoryName = "Biografi" },
                new CategoryModel() { Id = 4, CategoryName = "Spänning" },
                new CategoryModel() { Id = 5, CategoryName = "Romaner" },
                new CategoryModel() { Id = 6, CategoryName = "Historia" },
                new CategoryModel() { Id = 7, CategoryName = "Fantasy & SciFi" },
                new CategoryModel() { Id = 8, CategoryName = "Fakta" });

        }
    }
}
