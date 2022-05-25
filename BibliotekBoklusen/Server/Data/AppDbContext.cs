﻿using Microsoft.EntityFrameworkCore;

namespace BibliotekBoklusen.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Seminarium> Seminariums { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationStatus> ReservationStatuses { get; set; }
        public DbSet<ProductCopy> productCopies { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductCopy>().HasKey(p => new { p.Id, p.ProductId });


            modelBuilder.Entity<Category>()
                .HasData(new Category() { Id = 1, CategoryName = "Deckare" },
                new Category() { Id = 2, CategoryName = "Feelgood" },
                new Category() { Id = 3, CategoryName = "Biografi" },
                new Category() { Id = 4, CategoryName = "Spänning" },
                new Category() { Id = 5, CategoryName = "Romaner" },
                new Category() { Id = 6, CategoryName = "Historia" },
                new Category() { Id = 7, CategoryName = "Fantasy & SciFi" },
                new Category() { Id = 8, CategoryName = "Fakta" });

        }
    }
}
