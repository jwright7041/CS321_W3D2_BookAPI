using System;
using CS321_W3D2_BookAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CS321_W3D2_BookAPI.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        // TODO: implement a DbSet<Author> property
        public DbSet<Author> Authors { get; set; }

        // This method runs once when the DbContext is first used.
        public BookContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=books.db");
            base.OnConfiguring(optionsBuilder);
        }
        // This method runs once when the DbContext is first used.
        // It's a place where we can customize how EF Core maps our
        // model to the database. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: configure some seed data in the authors table


            modelBuilder.Entity<Author>().HasData(
                 new Author { id = 1, FirstName = "John", LastName = "Steinbeck", Birthdate = new DateTime(1902, 2, 27) },
                 new Author { id = 2, FirstName = "Stephen", LastName = "King", Birthdate = new DateTime(1947, 9, 21) }
            );

            // TODO: configure some seed data in the books table
            modelBuilder.Entity<Book>().HasData(
             new Book { Id = 1, Title = "The Grapes of Wrath", AuthorId = 1 },
             new Book { Id = 2, Title = "Cannery Row", AuthorId = 1 },
             new Book { Id = 3, Title = "The Shining", AuthorId = 2 }
         );
            base.OnModelCreating(modelBuilder);
        }

    }
}

