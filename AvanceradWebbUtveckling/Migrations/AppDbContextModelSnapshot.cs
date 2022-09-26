﻿// <auto-generated />
using System;
using AvanceradWebbUtveckling.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AvanceradWebbUtveckling.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AvanceradWebbUtveckling.Models.Book", b =>
                {
                    b.Property<int>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountOfBooks")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int?>("LoanID")
                        .HasColumnType("int");

                    b.HasKey("BookID");

                    b.HasIndex("LoanID");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookID = 2,
                            AmountOfBooks = 0,
                            Author = "Anas",
                            BookDescription = "Awesome adventure book",
                            BookName = "Sagan om ringen 1",
                            IsAvailable = true
                        },
                        new
                        {
                            BookID = 3,
                            AmountOfBooks = 0,
                            Author = "Anas",
                            BookDescription = "Awesome adventure book sequel",
                            BookName = "Sagan om ringen 2",
                            IsAvailable = true
                        });
                });

            modelBuilder.Entity("AvanceradWebbUtveckling.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("LoanID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoanID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AvanceradWebbUtveckling.Models.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.HasKey("LoanID");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            LoanID = 1,
                            BookID = 1,
                            CustomerID = 1,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsReturned = false
                        });
                });

            modelBuilder.Entity("AvanceradWebbUtveckling.Models.Book", b =>
                {
                    b.HasOne("AvanceradWebbUtveckling.Models.Loan", null)
                        .WithMany("Books")
                        .HasForeignKey("LoanID");
                });

            modelBuilder.Entity("AvanceradWebbUtveckling.Models.Customer", b =>
                {
                    b.HasOne("AvanceradWebbUtveckling.Models.Loan", null)
                        .WithMany("Customer")
                        .HasForeignKey("LoanID");
                });
#pragma warning restore 612, 618
        }
    }
}
