﻿// <auto-generated />
using System;
using BibliotekBoklusen.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BibliotekBoklusen.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BibliotekBoklusen.Shared.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isChecked")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Deckare",
                            isChecked = false
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Feelgood",
                            isChecked = false
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Biografi",
                            isChecked = false
                        },
                        new
                        {
                            Id = 4,
                            CategoryName = "Spänning",
                            isChecked = false
                        },
                        new
                        {
                            Id = 5,
                            CategoryName = "Romaner",
                            isChecked = false
                        },
                        new
                        {
                            Id = 6,
                            CategoryName = "Historia",
                            isChecked = false
                        },
                        new
                        {
                            Id = 7,
                            CategoryName = "Fantasy & SciFi",
                            isChecked = false
                        },
                        new
                        {
                            Id = 8,
                            CategoryName = "Fakta",
                            isChecked = false
                        });
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.CreatorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.Fine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("FineAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("FineDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LoanId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.HasIndex("UserId");

                    b.ToTable("Fines");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.FinePayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("PaymentAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("FinePayments");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.LoanModel", b =>
                {
                    b.Property<int>("CopyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CopyId"), 1L, 1);

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CopyId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.ProductCreatorModel", b =>
                {
                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CreatorId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCreator");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("PublishYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.ReservationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReservationStatusId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ReservationStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.ReservationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReservationStatuses");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.SeminariumModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DayAndTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Seminariums");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.CreatorModel", b =>
                {
                    b.HasOne("BibliotekBoklusen.Shared.ProductModel", "Product")
                        .WithMany("Creators")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.Fine", b =>
                {
                    b.HasOne("BibliotekBoklusen.Shared.LoanModel", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanId");

                    b.HasOne("BibliotekBoklusen.Shared.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Loan");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.FinePayment", b =>
                {
                    b.HasOne("BibliotekBoklusen.Shared.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.LoanModel", b =>
                {
                    b.HasOne("BibliotekBoklusen.Shared.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("BibliotekBoklusen.Shared.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.ProductCreatorModel", b =>
                {
                    b.HasOne("BibliotekBoklusen.Shared.CreatorModel", "Creator")
                        .WithMany("ProductCreators")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BibliotekBoklusen.Shared.ProductModel", "Product")
                        .WithMany("ProductCreators")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.ProductModel", b =>
                {
                    b.HasOne("BibliotekBoklusen.Shared.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.ReservationModel", b =>
                {
                    b.HasOne("BibliotekBoklusen.Shared.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("BibliotekBoklusen.Shared.ReservationModel", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationStatusId");

                    b.HasOne("BibliotekBoklusen.Shared.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Product");

                    b.Navigation("Reservation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.CreatorModel", b =>
                {
                    b.Navigation("ProductCreators");
                });

            modelBuilder.Entity("BibliotekBoklusen.Shared.ProductModel", b =>
                {
                    b.Navigation("Creators");

                    b.Navigation("ProductCreators");
                });
#pragma warning restore 612, 618
        }
    }
}
