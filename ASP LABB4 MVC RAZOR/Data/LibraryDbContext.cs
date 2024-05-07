using ASP_LABB4_MVC_RAZOR.Models.YourNamespace.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ASP_LABB4_MVC_RAZOR.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                .HasKey(l => l.LoanId);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Customer)
                .WithMany(c => c.Loans)
                .HasForeignKey(l => l.CustomerId);

            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId);

            modelBuilder.Entity<Customer>().HasData(
                new { UserId = 1, Username = "user1", Password = "pass1", Name = "Emma Thomas", Address = "123 Lane", Email = "emma.thomas@example.com", PhoneNumber = "111-222-3333" },
                new { UserId = 2, Username = "user2", Password = "pass2", Name = "Liam Johnson", Address = "124 Lane", Email = "liam.johnson@example.com", PhoneNumber = "222-333-4444" },
                new { UserId = 3, Username = "user3", Password = "pass3", Name = "Olivia Williams", Address = "125 Lane", Email = "olivia.williams@example.com", PhoneNumber = "333-444-5555" },
                new { UserId = 4, Username = "user4", Password = "pass4", Name = "Noah Jones", Address = "126 Lane", Email = "noah.jones@example.com", PhoneNumber = "444-555-6666" },
                new { UserId = 5, Username = "user5", Password = "pass5", Name = "Sophia Brown", Address = "127 Lane", Email = "sophia.brown@example.com", PhoneNumber = "555-666-7777" }
            );

            modelBuilder.Entity<Admin>().HasData(
                new { UserId = 6, Username = "admin", Password = "admin123", Name = "Super Admin" }
            );

            modelBuilder.Entity<Book>().HasData(
                new { BookId = 1, Title = "Shadows Over Bregdan", Author = "Genevieve Crownson" },
                new { BookId = 2, Title = "The Azure Stone", Author = "Sylvia Greystone" },
                new { BookId = 3, Title = "River of Secrets", Author = "Randall Thomas" },
                new { BookId = 4, Title = "Mysteries of Greenfield", Author = "Clara Wood" },
                new { BookId = 5, Title = "Guardians of Lore", Author = "Phillip Rowley" },
                new { BookId = 6, Title = "The Last Heir", Author = "Edward Lance" },
                new { BookId = 7, Title = "The Crystal Duel", Author = "Mara Lynn" },
                new { BookId = 8, Title = "Twilight's Game", Author = "Derek Shimmer" },
                new { BookId = 9, Title = "Whispers of Yesterday", Author = "Eliza Mortin" },
                new { BookId = 10, Title = "Crown of Echoes", Author = "Rachel Forge" }
            );

            modelBuilder.Entity<Loan>().HasData(
                new { LoanId = 1, CustomerId = 1, BookId = 1, LoanDate = DateTime.Now.AddDays(-10), ReturnDate = (DateTime?)null, IsReturned = false },
                new { LoanId = 2, CustomerId = 1, BookId = 3, LoanDate = DateTime.Now.AddDays(-8), ReturnDate = (DateTime?)null, IsReturned = false },
                new { LoanId = 3, CustomerId = 2, BookId = 2, LoanDate = DateTime.Now.AddDays(-6), ReturnDate = (DateTime?)null, IsReturned = false },
                new { LoanId = 4, CustomerId = 2, BookId = 4, LoanDate = DateTime.Now.AddDays(-7), ReturnDate = (DateTime?)null, IsReturned = false },
                new { LoanId = 5, CustomerId = 3, BookId = 5, LoanDate = DateTime.Now.AddDays(-5), ReturnDate = (DateTime?)null, IsReturned = false },
                new { LoanId = 6, CustomerId = 4, BookId = 6, LoanDate = DateTime.Now.AddDays(-4), ReturnDate = (DateTime?)null, IsReturned = false },
                new { LoanId = 7, CustomerId = 4, BookId = 7, LoanDate = DateTime.Now.AddDays(-3), ReturnDate = (DateTime?)null, IsReturned = false },
                new { LoanId = 8, CustomerId = 5, BookId = 8, LoanDate = DateTime.Now.AddDays(-2), ReturnDate = (DateTime?)null, IsReturned = false },
                new { LoanId = 9, CustomerId = 5, BookId = 9, LoanDate = DateTime.Now.AddDays(-1), ReturnDate = (DateTime?)null, IsReturned = false }
            );
        }
    }
}