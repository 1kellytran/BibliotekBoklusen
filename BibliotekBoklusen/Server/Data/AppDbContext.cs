using Microsoft.EntityFrameworkCore;


namespace BibliotekBoklusen.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CreatorModel> Creators { get; set; }
        public DbSet<SeminariumModel> Seminarium { get; set; }
    }
}
