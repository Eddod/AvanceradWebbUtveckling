using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvanceradWebbUtveckling.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Loan> Loans { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookID = 2,
                BookName = "Sagan om ringen 1",
                Author = "Anas",
                BookDescription = "Awesome adventure book",
                IsAvailable = true

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                BookID = 3,
                BookName = "Sagan om ringen 2",
                Author = "Anas",
                BookDescription = "Awesome adventure book sequel",
                IsAvailable = true

            });
            modelBuilder.Entity<Loan>().HasData(new Loan
            {
                LoanID = 1,
                BookID = 1,
                CustomerID = 1,
                

            });
        }
    }
}
