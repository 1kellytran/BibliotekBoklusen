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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many to many (Creators can have many products that in turns have many Creators)
            modelBuilder.Entity<ProductCreatorModel>()
                .HasKey(cm => new { cm.CreatorId, cm.ProductId });
            modelBuilder.Entity<ProductCreatorModel>()
                .HasOne(cm => cm.Creator)
                .WithMany(c => c.ProductCreators)
                .HasForeignKey(cm => cm.CreatorId);
            modelBuilder.Entity<ProductCreatorModel>()
                .HasOne(cm => cm.Product)
                .WithMany(m => m.ProductCreators)
                .HasForeignKey(cm => cm.ProductId);

            // Restrict deletion of Creator on product delete (set Creator to null instead)
            modelBuilder.Entity<CreatorModel>()
                .HasOne(m => m.Product)
                .WithMany(c => c.Creators)
                .HasForeignKey(m => m.ProductId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
   
        }
    }
}
